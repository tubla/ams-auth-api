namespace ams.service.models;

public class LoginHistoryDto
{
    [JsonPropertyName("id")]
    public int HistoryId { get; set; }

    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("login_time")]
    public DateTimeOffset LoginTime { get; set; } = DateTimeOffset.UtcNow;

    [JsonPropertyName("ip_address")]
    public string IPAddress { get; set; } = string.Empty;

    [JsonPropertyName("device_info")]
    public string DeviceInfo { get; set; } = string.Empty;
}
