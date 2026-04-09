using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class IssueRelationConfiguration : IEntityTypeConfiguration<IssueRelation>
{
    public void Configure(EntityTypeBuilder<IssueRelation> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Type).HasConversion<string>().HasColumnType("text");

        builder.HasIndex(e => new { e.SourceIssueId, e.TargetIssueId, e.Type }).IsUnique();

        builder.HasOne(e => e.SourceIssue).WithMany(e => e.OutwardRelations).HasForeignKey(e => e.SourceIssueId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.TargetIssue).WithMany(e => e.InwardRelations).HasForeignKey(e => e.TargetIssueId).OnDelete(DeleteBehavior.Restrict);
    }
}
