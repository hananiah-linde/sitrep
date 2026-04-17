using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class Notification
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public NotificationType Type { get; set; }
    public string? IssueId { get; set; }
    public string? CommentId { get; set; }
    public string? ActorId { get; set; }
    public string Message { get; set; } = null!;
    public bool IsRead { get; set; }
    public DateTimeOffset? ReadAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public User User { get; set; } = null!;
    public Issue? Issue { get; set; }
    public Comment? Comment { get; set; }
    public User? Actor { get; set; }
}
