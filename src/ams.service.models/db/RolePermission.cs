namespace ams.service.models;

public class RolePermission
{
    public int RolePermissionId { get; set; }
    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    // Navigation Properties
    public Role Role { get; set; } = new();
    public Permission Permission { get; set; } = new();
}
