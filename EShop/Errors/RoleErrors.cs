namespace EShop.Errors;

public static class RoleErrors
{
    public static Error DuplicateRole => new ("Role.DuplicateRole", "This role is already exists", StatusCodes.Status404NotFound);
    public static Error NotFound => new("Role.NotFound", "No role was found with this id", StatusCodes.Status404NotFound);
    public static Error InvalidPermission => new("Role.InvalidPermission", "No such permission was found", StatusCodes.Status404NotFound);
}
