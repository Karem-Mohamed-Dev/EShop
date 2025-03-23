namespace EShop.Errors;

public static class RoleErrors
{
    public static Error DuplicateRole => new ("Role.DuplicateRole", "This role is already exists", StatusCodes.Status400BadRequest);
    public static Error NotFound => new("Role.NotFound", "No role was found with this id", StatusCodes.Status404NotFound);
    public static Error InvalidPermission => new("Role.InvalidPermission", "No such permission was found", StatusCodes.Status400BadRequest);
    public static Error DuplicateRoleAssign => new("Role.InvalidPermission", "This user is already assigned to this role", StatusCodes.Status400BadRequest);
    public static Error UserRoleNotFound => new("Role.UserRoleNotFound", "This user is not assigned to this role", StatusCodes.Status400BadRequest);
}
