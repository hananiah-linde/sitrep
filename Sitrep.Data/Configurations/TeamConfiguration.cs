using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasColumnType("text");
        builder.Property(e => e.Identifier).HasColumnType("text");
        builder.Property(e => e.Description).HasColumnType("text");
        builder.Property(e => e.Color).HasColumnType("text");
        builder.Property(e => e.IconUrl).HasColumnType("text");
        builder.Property(e => e.IssueCounter).UseIdentityAlwaysColumn();

        builder.HasIndex(e => new { e.WorkspaceId, e.Identifier }).IsUnique();

        builder.HasOne(e => e.Workspace).WithMany(e => e.Teams).HasForeignKey(e => e.WorkspaceId);

        builder.HasQueryFilter(e => e.ArchivedAt == null);
    }
}
