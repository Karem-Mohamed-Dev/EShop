namespace EShop.Entities;

public class RefreshToken
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedByIp { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(7);
    public DateTime? RevokedAt { get; set; }
    public string? RevokedByIp { get; set; } = string.Empty;

    public bool IsExpired => ExpiresAt < DateTime.UtcNow;
    public bool IsActive => !IsExpired && RevokedAt is null;
    public User User { get; set; } = default!;
}
