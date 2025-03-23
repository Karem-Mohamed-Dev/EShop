using System.Security.Claims;

namespace EShop;

public static class Extintions
{
    public static Guid GetId(this ClaimsPrincipal claim) =>
        Guid.Parse(claim.FindFirst(ClaimTypes.NameIdentifier)!.Value);
}
