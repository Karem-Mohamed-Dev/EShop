using Microsoft.AspNetCore.Authorization;

namespace EShop.Authentication.Filters;

public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
{
}
