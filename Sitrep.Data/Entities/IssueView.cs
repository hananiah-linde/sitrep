namespace Sitrep.Data.Entities;

public class IssueView
{
    public Guid Id { get; set; }
    public Guid WorkspaceId { get; set; }
    public Guid? TeamId { get; set; }
    public Guid? OwnerId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string FilterConfig { get; set; } = null!;
    public bool IsShared { get; set; }
    public int SortOrder { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public Workspace Workspace { get; set; } = null!;
    public Team? Team { get; set; }
    public User? Owner { get; set; }
}
