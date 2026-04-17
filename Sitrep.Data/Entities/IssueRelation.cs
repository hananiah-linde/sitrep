using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class IssueRelation
{
    public string Id { get; set; }
    public string SourceIssueId { get; set; }
    public string TargetIssueId { get; set; }
    public IssueRelationType Type { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public Issue SourceIssue { get; set; } = null!;
    public Issue TargetIssue { get; set; } = null!;
}
