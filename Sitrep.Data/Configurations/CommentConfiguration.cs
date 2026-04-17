using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Body).HasColumnType("text");

        builder.HasOne(e => e.Issue).WithMany(e => e.Comments).HasForeignKey(e => e.IssueId);
        builder.HasOne(e => e.Author).WithMany(e => e.Comments).HasForeignKey(e => e.AuthorId);
        builder.HasOne(e => e.ParentComment).WithMany(e => e.Replies).HasForeignKey(e => e.ParentCommentId).OnDelete(DeleteBehavior.Restrict);
    }
}
