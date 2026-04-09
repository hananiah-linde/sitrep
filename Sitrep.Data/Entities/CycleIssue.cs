namespace Sitrep.Data.Entities;

public class CycleIssue
{
    public Guid CycleId { get; set; }
    public Guid IssueId { get; set; }
    public bool IsRolledOver { get; set; }
    public DateTimeOffset AddedAt { get; set; }

    public Cycle Cycle { get; set; } = null!;
    public Issue Issue { get; set; } = null!;
}
