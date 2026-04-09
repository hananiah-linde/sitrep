namespace Sitrep.Data.Entities;

public class InitiativeProject
{
    public Guid InitiativeId { get; set; }
    public Guid ProjectId { get; set; }
    public int SortOrder { get; set; }
    public DateTimeOffset AddedAt { get; set; }

    public Initiative Initiative { get; set; } = null!;
    public Project Project { get; set; } = null!;
}
