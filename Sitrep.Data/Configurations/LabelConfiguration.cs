using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class LabelConfiguration : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasColumnType("text");
        builder.Property(e => e.Color).HasColumnType("text");
        builder.Property(e => e.Description).HasColumnType("text");

        builder.HasOne(e => e.Workspace).WithMany(e => e.Labels).HasForeignKey(e => e.WorkspaceId);
        builder.HasOne(e => e.Team).WithMany(e => e.Labels).HasForeignKey(e => e.TeamId);
    }
}
