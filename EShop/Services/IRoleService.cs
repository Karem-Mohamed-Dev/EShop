namespace EShop.Services;

public interface IRoleService
{
    Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false ,CancellationToken cancellationToken = default);
    Task<Result<RoleDetailsResponse>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<RoleDetailsResponse>> AddAsync(RoleRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(Guid id, RoleRequest request, CancellationToken cancellationToken = default);
    Task<Result> ToggleDisableAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result> AssignUserRoleAsync(UserRoleRequest request, CancellationToken cancellationToken = default);
    Task<Result> RemoveUserRoleAsync(UserRoleRequest request, CancellationToken cancellationToken = default);
}