namespace Sitrep.Data.Entities;

public class Cycle
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }
    public string Name { get; set; } = null!;
    public int Number { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public Team Team { get; set; } = null!;
    public ICollection<CycleIssue> CycleIssues { get; set; } = [];
}
