using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class CycleIssueConfiguration : IEntityTypeConfiguration<CycleIssue>
{
    public void Configure(EntityTypeBuilder<CycleIssue> builder)
    {
        builder.HasKey(e => new { e.CycleId, e.IssueId });

        builder.HasOne(e => e.Cycle).WithMany(e => e.CycleIssues).HasForeignKey(e => e.CycleId);
        builder.HasOne(e => e.Issue).WithMany(e => e.CycleIssues).HasForeignKey(e => e.IssueId);
    }
}
