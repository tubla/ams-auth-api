namespace ams.service.models;

public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public List<UserRole> UserRoles { get; set; } = [];
    public List<LoginHistory> LoginHistories { get; set; } = [];
}