using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class ProjectMember
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid UserId { get; set; }
    public MemberRole Role { get; set; }
    public DateTimeOffset JoinedAt { get; set; }

    public Project Project { get; set; } = null!;
    public User User { get; set; } = null!;
}
