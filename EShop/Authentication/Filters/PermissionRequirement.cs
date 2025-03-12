using Microsoft.AspNetCore.Authorization;

namespace EShop.Authentication.Filters;

public class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}
