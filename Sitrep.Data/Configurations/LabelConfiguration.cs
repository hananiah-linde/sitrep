using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class LabelConfiguration : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(50);
        builder.Property(e => e.Color).HasMaxLength(7);
        builder.Property(e => e.Description).HasMaxLength(255);

        builder.HasOne(e => e.Workspace).WithMany(e => e.Labels).HasForeignKey(e => e.WorkspaceId);
        builder.HasOne(e => e.Team).WithMany(e => e.Labels).HasForeignKey(e => e.TeamId);
    }
}
