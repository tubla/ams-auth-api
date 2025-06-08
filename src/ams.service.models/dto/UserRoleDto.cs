namespace ams.service.models;

public class UserRoleDto
{
    [JsonPropertyName("id")]
    public int UserRoleId { get; set; }

    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("role_id")]
    public int RoleId { get; set; }
}
