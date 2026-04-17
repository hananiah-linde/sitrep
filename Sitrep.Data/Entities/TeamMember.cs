using Sitrep.Data.Enums;

namespace Sitrep.Data.Entities;

public class TeamMember
{
    public string Id { get; set; }
    public string TeamId { get; set; }
    public string UserId { get; set; }
    public MemberRole Role { get; set; }
    public DateTimeOffset JoinedAt { get; set; }

    public Team Team { get; set; } = null!;
    public User User { get; set; } = null!;
}
