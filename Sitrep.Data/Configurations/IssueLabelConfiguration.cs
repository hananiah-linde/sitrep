using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class IssueLabelConfiguration : IEntityTypeConfiguration<IssueLabel>
{
    public void Configure(EntityTypeBuilder<IssueLabel> builder)
    {
        builder.HasKey(e => new { e.IssueId, e.LabelId });

        builder.HasOne(e => e.Issue).WithMany(e => e.Labels).HasForeignKey(e => e.IssueId);
        builder.HasOne(e => e.Label).WithMany(e => e.IssueLabels).HasForeignKey(e => e.LabelId);
    }
}
