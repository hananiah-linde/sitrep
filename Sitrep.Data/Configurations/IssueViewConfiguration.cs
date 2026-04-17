using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class IssueViewConfiguration : IEntityTypeConfiguration<IssueView>
{
    public void Configure(EntityTypeBuilder<IssueView> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.FilterConfig).HasColumnType("jsonb");

        builder.HasOne(e => e.Workspace).WithMany(e => e.IssueViews).HasForeignKey(e => e.WorkspaceId);
        builder.HasOne(e => e.Team).WithMany().HasForeignKey(e => e.TeamId);
        builder.HasOne(e => e.Owner).WithMany().HasForeignKey(e => e.OwnerId);
    }
}
