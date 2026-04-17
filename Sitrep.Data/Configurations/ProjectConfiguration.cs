using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Description).HasColumnType("text");
        builder.Property(e => e.Status).HasConversion<string>().HasMaxLength(50);
        builder.Property(e => e.Color).HasMaxLength(7);
        builder.Property(e => e.IconUrl).HasMaxLength(1000);

        builder.HasOne(e => e.Workspace).WithMany(e => e.Projects).HasForeignKey(e => e.WorkspaceId);
        builder.HasOne(e => e.Lead).WithMany().HasForeignKey(e => e.LeadId);
        builder.HasOne(e => e.CreatedBy).WithMany().HasForeignKey(e => e.CreatedById).OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(e => e.ArchivedAt == null);
    }
}
