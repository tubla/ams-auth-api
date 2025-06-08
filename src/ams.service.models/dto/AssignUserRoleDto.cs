namespace ams.service.models;

public class AssignUserRoleDto
{
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("role_id")]
    public int RoleId { get; set; }
}
