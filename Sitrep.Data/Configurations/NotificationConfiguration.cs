using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Type).HasConversion<string>().HasMaxLength(50);
        builder.Property(e => e.Message).HasMaxLength(500);

        builder.HasIndex(e => new { e.UserId, e.IsRead });
        builder.HasIndex(e => e.UserId);

        builder.HasOne(e => e.User).WithMany(e => e.Notifications).HasForeignKey(e => e.UserId);
        builder.HasOne(e => e.Issue).WithMany().HasForeignKey(e => e.IssueId);
        builder.HasOne(e => e.Comment).WithMany().HasForeignKey(e => e.CommentId);
        builder.HasOne(e => e.Actor).WithMany().HasForeignKey(e => e.ActorId);
    }
}
