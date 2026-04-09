using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Emoji).HasColumnType("text");

        builder.HasIndex(e => new { e.CommentId, e.UserId, e.Emoji }).IsUnique();

        builder.HasOne(e => e.Comment).WithMany(e => e.Reactions).HasForeignKey(e => e.CommentId);
        builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
    }
}
