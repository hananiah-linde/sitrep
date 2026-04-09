namespace Sitrep.Data.Entities;

public class Workspace
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string? LogoUrl { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public ICollection<WorkspaceMember> Members { get; set; } = [];
    public ICollection<Team> Teams { get; set; } = [];
    public ICollection<Project> Projects { get; set; } = [];
    public ICollection<Initiative> Initiatives { get; set; } = [];
    public ICollection<Label> Labels { get; set; } = [];
    public ICollection<IssueView> IssueViews { get; set; } = [];
}
