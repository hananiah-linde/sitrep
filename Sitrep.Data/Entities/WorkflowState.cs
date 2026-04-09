using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class WorkflowState
{
    public Guid Id { get; set; }
    public Guid WorkflowId { get; set; }
    public string Name { get; set; } = null!;
    public WorkflowStateCategory Category { get; set; }
    public string Color { get; set; } = null!;
    public int Position { get; set; }
    public bool IsDefault { get; set; }
    public string? Description { get; set; }

    public Workflow Workflow { get; set; } = null!;
    public ICollection<Issue> Issues { get; set; } = [];
}
