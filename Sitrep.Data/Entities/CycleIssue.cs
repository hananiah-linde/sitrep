namespace Sitrep.Data.Entities;

public class CycleIssue
{
    public string CycleId { get; set; }
    public string IssueId { get; set; }
    public bool IsRolledOver { get; set; }
    public DateTimeOffset AddedAt { get; set; }

    public Cycle Cycle { get; set; } = null!;
    public Issue Issue { get; set; } = null!;
}