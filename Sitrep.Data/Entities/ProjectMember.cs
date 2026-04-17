using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class ProjectMember
{
    public string Id { get; set; }
    public string ProjectId { get; set; }
    public string UserId { get; set; }
    public MemberRole Role { get; set; }
    public DateTimeOffset JoinedAt { get; set; }

    public Project Project { get; set; } = null!;
    public User User { get; set; } = null!;
}
