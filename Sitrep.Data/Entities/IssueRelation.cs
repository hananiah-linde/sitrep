using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class IssueRelation
{
    public Guid Id { get; set; }
    public Guid SourceIssueId { get; set; }
    public Guid TargetIssueId { get; set; }
    public IssueRelationType Type { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public Issue SourceIssue { get; set; } = null!;
    public Issue TargetIssue { get; set; } = null!;
}
