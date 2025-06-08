namespace ams.service.models;

public class RolePermissionDto
{
    [JsonPropertyName("id")]
    public int RolePermissionId { get; set; }

    [JsonPropertyName("role_id")]
    public int RoleId { get; set; }

    [JsonPropertyName("permission_id")]
    public int PermissionId { get; set; }
}
