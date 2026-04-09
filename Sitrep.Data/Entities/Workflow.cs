namespace Sitrep.Data.Entities;

public class Workflow
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }
    public string Name { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public Team Team { get; set; } = null!;
    public ICollection<WorkflowState> States { get; set; } = [];
}
