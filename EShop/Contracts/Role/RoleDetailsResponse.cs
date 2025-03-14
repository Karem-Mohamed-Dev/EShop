namespace EShop.Contracts.Role;

public record RoleDetailsResponse(string Id, string Name, bool IsDisabled, IEnumerable<string> Permissions);