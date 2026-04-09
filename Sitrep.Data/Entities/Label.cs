namespace Sitrep.Data.Entities;

public class Label
{
    public Guid Id { get; set; }
    public Guid WorkspaceId { get; set; }
    public Guid? TeamId { get; set; }
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public Workspace Workspace { get; set; } = null!;
    public Team? Team { get; set; }
    public ICollection<IssueLabel> IssueLabels { get; set; } = [];
}
