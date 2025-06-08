namespace ams.service.models;

public class LoginHistory
{
    public int HistoryId { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset LoginTime { get; set; } = DateTimeOffset.UtcNow;
    public string IPAddress { get; set; } = string.Empty;
    public string DeviceInfo { get; set; } = string.Empty;

    // Navigation Property
    public User User { get; set; } = new();
}
