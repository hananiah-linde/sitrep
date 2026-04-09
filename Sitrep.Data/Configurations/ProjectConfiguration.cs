using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasColumnType("text");
        builder.Property(e => e.Description).HasColumnType("text");
        builder.Property(e => e.Status).HasConversion<string>().HasColumnType("text");
        builder.Property(e => e.Color).HasColumnType("text");
        builder.Property(e => e.IconUrl).HasColumnType("text");

        builder.HasOne(e => e.Workspace).WithMany(e => e.Projects).HasForeignKey(e => e.WorkspaceId);
        builder.HasOne(e => e.Lead).WithMany().HasForeignKey(e => e.LeadId);
        builder.HasOne(e => e.CreatedBy).WithMany().HasForeignKey(e => e.CreatedById).OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(e => e.ArchivedAt == null);
    }
}
