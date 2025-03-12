using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication;

public class MailSettings
{
    public const string Name = "MailSettings";
    [Required]
    public string Host { get; set; } = string.Empty;
    [Range(1, 999)]
    public int Port { get; set; }
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
