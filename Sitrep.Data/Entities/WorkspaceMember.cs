using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class WorkspaceMember
{
    public string Id { get; set; }
    public string WorkspaceId { get; set; }
    public string UserId { get; set; }
    public MemberRole Role { get; set; }
    public DateTimeOffset JoinedAt { get; set; }

    public Workspace Workspace { get; set; } = null!;
    public User User { get; set; } = null!;
}
