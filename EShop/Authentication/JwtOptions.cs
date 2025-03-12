using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication;

public class JwtOptions
{
    public const string Name = "Jwt";
    [Required]
    public string Key { get; set; } = string.Empty;
    [Required]
    public string Issuer { get; set; } = string.Empty;
    [Required]
    public string Audience { get; set; } = string.Empty;
    [Range(1,999)]
    public int ExpiryMinutes {  get; set; }
}
