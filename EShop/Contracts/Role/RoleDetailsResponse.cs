namespace EShop.Contracts.Role;

public record RoleDetailsResponse(Guid Id, string Name, bool IsDisabled, IEnumerable<string> Permissions);