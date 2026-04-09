namespace Sitrep.Data.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string? AvatarUrl { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public ICollection<WorkspaceMember> WorkspaceMemberships { get; set; } = [];
    public ICollection<Issue> AssignedIssues { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Notification> Notifications { get; set; } = [];
}
