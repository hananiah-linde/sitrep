namespace Sitrep.Data.Entities;

public class Attachment
{
    public string Id { get; set; }
    public string IssueId { get; set; }
    public string UploadedById { get; set; }
    public string FileName { get; set; } = null!;
    public long FileSize { get; set; }
    public string ContentType { get; set; } = null!;
    public string StorageUrl { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }

    public Issue Issue { get; set; } = null!;
    public User UploadedBy { get; set; } = null!;
}