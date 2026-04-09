using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class Issue
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }
    public Guid WorkflowStateId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public IssuePriority Priority { get; set; }
    public int? Estimate { get; set; }
    public int Number { get; set; }
    public Guid? AssigneeId { get; set; }
    public Guid CreatedById { get; set; }
    public Guid? ParentIssueId { get; set; }
    public Guid? ProjectId { get; set; }
    public Guid? MilestoneId { get; set; }
    public DateOnly? DueDate { get; set; }
    public double SortOrder { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public DateTimeOffset? ArchivedAt { get; set; }

    public Team Team { get; set; } = null!;
    public WorkflowState WorkflowState { get; set; } = null!;
    public User? Assignee { get; set; }
    public User CreatedBy { get; set; } = null!;
    public Issue? ParentIssue { get; set; }
    public ICollection<Issue> SubIssues { get; set; } = [];
    public Project? Project { get; set; }
    public Milestone? Milestone { get; set; }
    public ICollection<IssueLabel> Labels { get; set; } = [];
    public ICollection<IssueRelation> OutwardRelations { get; set; } = [];
    public ICollection<IssueRelation> InwardRelations { get; set; } = [];
    public ICollection<CycleIssue> CycleIssues { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Attachment> Attachments { get; set; } = [];
    public ICollection<IssueActivity> Activities { get; set; } = [];
}
