using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class Notification
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public NotificationType Type { get; set; }
    public Guid? IssueId { get; set; }
    public Guid? CommentId { get; set; }
    public Guid? ActorId { get; set; }
    public string Message { get; set; } = null!;
    public bool IsRead { get; set; }
    public DateTimeOffset? ReadAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public User User { get; set; } = null!;
    public Issue? Issue { get; set; }
    public Comment? Comment { get; set; }
    public User? Actor { get; set; }
}
