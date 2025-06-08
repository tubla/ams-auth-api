namespace ams.service.models;

public class AssignRolePermissionDto
{
    [JsonPropertyName("role_id")]
    public int RoleId { get; set; }

    [JsonPropertyName("permission_id")]
    public int PermissionId { get; set; }
}
