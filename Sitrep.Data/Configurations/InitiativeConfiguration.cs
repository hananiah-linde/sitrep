using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class InitiativeConfiguration : IEntityTypeConfiguration<Initiative>
{
    public void Configure(EntityTypeBuilder<Initiative> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Description).HasColumnType("text");
        builder.Property(e => e.Color).HasMaxLength(7);

        builder.HasOne(e => e.Workspace).WithMany(e => e.Initiatives).HasForeignKey(e => e.WorkspaceId);
        builder.HasOne(e => e.Owner).WithMany().HasForeignKey(e => e.OwnerId);
        builder.HasOne(e => e.CreatedBy).WithMany().HasForeignKey(e => e.CreatedById).OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(e => e.ArchivedAt == null);
    }
}
