using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class TeamMember
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }
    public Guid UserId { get; set; }
    public MemberRole Role { get; set; }
    public DateTimeOffset JoinedAt { get; set; }

    public Team Team { get; set; } = null!;
    public User User { get; set; } = null!;
}
