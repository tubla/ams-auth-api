namespace ams.service.models;

public class Permission
{
    public int PermissionId { get; set; }
    public string PermissionName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    // Navigation Property
    public List<RolePermission> RolePermissions { get; set; } = [];
}
