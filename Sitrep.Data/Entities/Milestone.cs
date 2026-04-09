namespace Sitrep.Data.Entities;

public class Milestone
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly? TargetDate { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public int SortOrder { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public Project Project { get; set; } = null!;
    public ICollection<Issue> Issues { get; set; } = [];
}
