namespace EShop.Contracts.Role;

public record RoleRequest(string Name, IEnumerable<string> Permissions);