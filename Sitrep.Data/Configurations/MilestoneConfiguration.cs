using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class MilestoneConfiguration : IEntityTypeConfiguration<Milestone>
{
    public void Configure(EntityTypeBuilder<Milestone> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasColumnType("text");
        builder.Property(e => e.Description).HasColumnType("text");

        builder.HasOne(e => e.Project).WithMany(e => e.Milestones).HasForeignKey(e => e.ProjectId);
    }
}
