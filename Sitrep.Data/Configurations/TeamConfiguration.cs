using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Identifier).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.Color).HasMaxLength(7);
        builder.Property(e => e.IconUrl).HasMaxLength(1000);
        builder.Property(e => e.IssueCounter).UseIdentityAlwaysColumn();

        builder.HasIndex(e => new { e.WorkspaceId, e.Identifier }).IsUnique();

        builder.HasOne(e => e.Workspace).WithMany(e => e.Teams).HasForeignKey(e => e.WorkspaceId);

        builder.HasQueryFilter(e => e.ArchivedAt == null);
    }
}
