namespace Sitrep.Data.Entities;

public class IssueLabel
{
    public string IssueId { get; set; }
    public string LabelId { get; set; }

    public Issue Issue { get; set; } = null!;
    public Label Label { get; set; } = null!;
}
