namespace Sitrep.Data.Entities;

public class IssueActivity
{
    public Guid Id { get; set; }
    public Guid IssueId { get; set; }
    public Guid ActorId { get; set; }
    public string Type { get; set; } = null!;
    public string? FromValue { get; set; }
    public string? ToValue { get; set; }
    public string? Metadata { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public Issue Issue { get; set; } = null!;
    public User Actor { get; set; } = null!;
}
