namespace ams.service.models;

public class PermissionDto
{
    [JsonPropertyName("id")]
    public int PermissionId { get; set; }
    [JsonPropertyName("permission_name")]
    public string PermissionName { get; set; } = string.Empty;
    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;
}
