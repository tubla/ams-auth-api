namespace ams.service.models;

public class RoleDto
{
    [JsonPropertyName("id")]
    public int RoleId { get; set; }

    [JsonPropertyName("role_name")]
    public string RoleName { get; set; } = string.Empty;
}