namespace Sitrep.Data.Entities;

public class Attachment
{
    public Guid Id { get; set; }
    public Guid IssueId { get; set; }
    public Guid UploadedById { get; set; }
    public string FileName { get; set; } = null!;
    public long FileSize { get; set; }
    public string ContentType { get; set; } = null!;
    public string StorageUrl { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }

    public Issue Issue { get; set; } = null!;
    public User UploadedBy { get; set; } = null!;
}
