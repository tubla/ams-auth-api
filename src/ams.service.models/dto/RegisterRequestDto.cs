namespace ams.service.models;

public class RegisterRequestDto
{
    [JsonPropertyName("full_name")]
    public string FullName { get; set; } = string.Empty;
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
