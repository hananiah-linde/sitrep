namespace Sitrep.Data.Entities;

public class InitiativeProject
{
    public string InitiativeId { get; set; }
    public string ProjectId { get; set; }
    public int SortOrder { get; set; }
    public DateTimeOffset AddedAt { get; set; }

    public Initiative Initiative { get; set; } = null!;
    public Project Project { get; set; } = null!;
}