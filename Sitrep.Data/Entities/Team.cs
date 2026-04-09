namespace Sitrep.Data.Entities;

public class Team
{
    public Guid Id { get; set; }
    public Guid WorkspaceId { get; set; }
    public string Name { get; set; } = null!;
    public string Identifier { get; set; } = null!;
    public string? Description { get; set; }
    public string? Color { get; set; }
    public string? IconUrl { get; set; }
    public bool TriageEnabled { get; set; }
    public bool CyclesEnabled { get; set; }
    public int IssueCounter { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset? ArchivedAt { get; set; }

    public Workspace Workspace { get; set; } = null!;
    public ICollection<TeamMember> Members { get; set; } = [];
    public ICollection<Issue> Issues { get; set; } = [];
    public ICollection<Workflow> Workflows { get; set; } = [];
    public ICollection<Cycle> Cycles { get; set; } = [];
    public ICollection<Label> Labels { get; set; } = [];
}
