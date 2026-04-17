namespace Sitrep.Data.Entities;

public class Reaction
{
    public string Id { get; set; }
    public string CommentId { get; set; }
    public string UserId { get; set; }
    public string Emoji { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }

    public Comment Comment { get; set; } = null!;
    public User User { get; set; } = null!;
}
