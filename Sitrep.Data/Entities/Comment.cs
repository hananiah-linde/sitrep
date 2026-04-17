namespace Sitrep.Data.Entities;

public class Comment
{
    public string Id { get; set; }
    public string IssueId { get; set; }
    public string AuthorId { get; set; }
    public string? ParentCommentId { get; set; }
    public string Body { get; set; } = null!;
    public DateTimeOffset? EditedAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    public Issue Issue { get; set; } = null!;
    public User Author { get; set; } = null!;
    public Comment? ParentComment { get; set; }
    public ICollection<Comment> Replies { get; set; } = [];
    public ICollection<Reaction> Reactions { get; set; } = [];
}