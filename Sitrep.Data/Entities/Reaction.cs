namespace Sitrep.Data.Entities;

public class Reaction
{
    public Guid Id { get; set; }
    public Guid CommentId { get; set; }
    public Guid UserId { get; set; }
    public string Emoji { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }

    public Comment Comment { get; set; } = null!;
    public User User { get; set; } = null!;
}
