namespace ams.service.models;

public class UserRole
{
    public int UserRoleId { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }

    // Navigation Properties
    public User User { get; set; } = new();
    public Role Role { get; set; } = new();
}
