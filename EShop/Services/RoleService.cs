using EShop.Persistence.Configurations.Seeding;

namespace EShop.Services;

public class RoleService(RoleManager<Role> roleManager, AppDbContext context) : IRoleService
{
    private readonly RoleManager<Role> _roleManager = roleManager;
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default) =>
        await _roleManager.Roles
        .Where(x => !x.IsDefault && (!x.IsDisabled || includeDisabled))
        .AsNoTracking()
        .ProjectToType<RoleResponse>()
        .ToListAsync(cancellationToken);

    public async Task<Result<RoleDetailsResponse>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not { } role)
            return Result.Failure<RoleDetailsResponse>(RoleErrors.NotFound);

        IEnumerable<string> permissions = (await _roleManager.GetClaimsAsync(role)).Select(x => x.Value);

        return Result.Success(new RoleDetailsResponse(id, role.Name!, role.IsDisabled, permissions));
    }

    public async Task<Result<RoleDetailsResponse>> AddAsync(RoleRequest request, CancellationToken cancellationToken = default)
    {
        var allowedPermissions = Permissions.GetAllPermissions();
        if (await _roleManager.RoleExistsAsync(request.Name))
            return Result.Failure<RoleDetailsResponse>(RoleErrors.DuplicateRole);

        if (request.Permissions.Except(allowedPermissions).Any())
            return Result.Failure<RoleDetailsResponse>(RoleErrors.InvalidPermission);

        var role = new Role() { Name = request.Name, ConcurrencyStamp = Guid.NewGuid().ToString() };
        var result = await _roleManager.CreateAsync(role);

        if (result.Succeeded)
        {
            var permissions = request.Permissions
                .Select(x => new IdentityRoleClaim<Guid>
                {
                    ClaimType = Permissions.Type,
                    ClaimValue = x,
                    RoleId = role.Id
                });

            await _context.RoleClaims.AddRangeAsync(permissions, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success(new RoleDetailsResponse(role.Id, role.Name!, role.IsDisabled, request.Permissions));
        }

        var error = result.Errors.First();
        return Result.Failure<RoleDetailsResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> UpdateAsync(Guid id, RoleRequest request, CancellationToken cancellationToken = default)
    {
        if (await _roleManager.Roles.AnyAsync(x => x.Name == request.Name && x.Id != id, cancellationToken))
            return Result.Failure(RoleErrors.DuplicateRole);

        if (await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not { } role)
            return Result.Failure(RoleErrors.NotFound);

        var allowedPermissions = Permissions.GetAllPermissions();

        if (request.Permissions.Except(allowedPermissions).Any())
            return Result.Failure(RoleErrors.InvalidPermission);


        role.Name = request.Name;
        var result = await _roleManager.UpdateAsync(role);

        if (result.Succeeded)
        {
            var oldPermissions = await _context.RoleClaims
                .Where(x => x.RoleId == id && x.ClaimType == Permissions.Type)
                .Select(x => x.ClaimValue)
                .ToListAsync(cancellationToken);

            var newPermissions = request.Permissions.Except(oldPermissions).Select(x => new IdentityRoleClaim<Guid>
            {
                ClaimType = Permissions.Type,
                ClaimValue = x,
                RoleId = id
            });

            var deletedPermissions = oldPermissions.Except(request.Permissions);
            await _context.RoleClaims
                .Where(x => x.RoleId == id && deletedPermissions.Contains(x.ClaimValue))
                .ExecuteDeleteAsync(cancellationToken);

            await _context.AddRangeAsync(newPermissions, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        var error = result.Errors.First();
        return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
    }

    public async Task<Result> ToggleDisableAsync(Guid id, CancellationToken cancellationToken = default)
    {
        if (await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken) is not { } role)
            return Result.Failure(RoleErrors.NotFound);

        role.IsDisabled = !role.IsDisabled;
        await _roleManager.UpdateAsync(role);

        return Result.Success();
    }

    public async Task<Result> AssignUserRoleAsync(UserRoleRequest request, CancellationToken cancellationToken = default)
    {
        Guid UserId = Guid.Parse(request.UserId);
        Guid RoleId = Guid.Parse(request.RoleId);

        if (!await _roleManager.Roles.AnyAsync(x => x.Id == RoleId, cancellationToken))
            return Result.Failure(RoleErrors.NotFound);

        if (!await _context.Users.AnyAsync(x => x.Id == UserId, cancellationToken))
            return Result.Failure(UserErrors.NotFound);

        if (await _context.UserRoles.AnyAsync(x => x.RoleId == RoleId && x.UserId == UserId, cancellationToken))
            return Result.Failure(RoleErrors.DuplicateRoleAssign);

        var userRole = new IdentityUserRole<Guid> { UserId = UserId , RoleId  = RoleId };
        await _context.AddAsync(userRole, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> RemoveUserRoleAsync(UserRoleRequest request, CancellationToken cancellationToken = default)
    {
        Guid UserId = Guid.Parse(request.UserId);
        Guid RoleId = Guid.Parse(request.RoleId);

        if (!await _roleManager.Roles.AnyAsync(x => x.Id == RoleId, cancellationToken))
            return Result.Failure(RoleErrors.NotFound);

        if (!await _context.Users.AnyAsync(x => x.Id == UserId, cancellationToken))
            return Result.Failure(UserErrors.NotFound);

        if (await _context.UserRoles.FirstOrDefaultAsync(x => x.RoleId == RoleId && x.UserId == UserId, cancellationToken) is not { } userRole)
            return Result.Failure(RoleErrors.UserRoleNotFound);

        _context.UserRoles.Remove(userRole);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}