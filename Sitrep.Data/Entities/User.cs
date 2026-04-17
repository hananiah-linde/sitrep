using Microsoft.AspNetCore.Identity;

namespace Sitrep.Data.Entities;

public class User : IdentityUser
{
    public string? ProfileImageUrl { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    public ICollection<WorkspaceMember> WorkspaceMemberships { get; set; } = [];
    public ICollection<Issue> AssignedIssues { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Notification> Notifications { get; set; } = [];
}