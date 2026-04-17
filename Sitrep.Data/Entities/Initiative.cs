namespace Sitrep.Data.Entities;

public class Initiative
{
    public string Id { get; set; }
    public string WorkspaceId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Color { get; set; }
    public string? OwnerId { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? TargetDate { get; set; }
    public string CreatedById { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset? ArchivedAt { get; set; }

    public Workspace Workspace { get; set; } = null!;
    public User? Owner { get; set; }
    public User CreatedBy { get; set; } = null!;
    public ICollection<InitiativeProject> InitiativeProjects { get; set; } = [];
}