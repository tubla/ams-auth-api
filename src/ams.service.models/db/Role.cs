namespace ams.service.models;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;

    // Navigation Properties
    public List<UserRole> UserRoles { get; set; } = [];
    public List<RolePermission> RolePermissions { get; set; } = [];
}