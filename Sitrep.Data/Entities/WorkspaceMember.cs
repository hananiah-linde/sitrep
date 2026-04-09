using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class WorkspaceMember
{
    public Guid Id { get; set; }
    public Guid WorkspaceId { get; set; }
    public Guid UserId { get; set; }
    public MemberRole Role { get; set; }
    public DateTimeOffset JoinedAt { get; set; }

    public Workspace Workspace { get; set; } = null!;
    public User User { get; set; } = null!;
}
