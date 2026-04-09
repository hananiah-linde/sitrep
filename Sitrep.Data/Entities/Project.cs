using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class Project
{
    public Guid Id { get; set; }
    public Guid WorkspaceId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ProjectStatus Status { get; set; }
    public string? Color { get; set; }
    public string? IconUrl { get; set; }
    public Guid? LeadId { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? TargetDate { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset? ArchivedAt { get; set; }

    public Workspace Workspace { get; set; } = null!;
    public User? Lead { get; set; }
    public User CreatedBy { get; set; } = null!;
    public ICollection<ProjectMember> Members { get; set; } = [];
    public ICollection<Milestone> Milestones { get; set; } = [];
    public ICollection<Issue> Issues { get; set; } = [];
    public ICollection<InitiativeProject> InitiativeProjects { get; set; } = [];
}
