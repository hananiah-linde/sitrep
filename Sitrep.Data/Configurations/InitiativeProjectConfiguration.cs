using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class InitiativeProjectConfiguration : IEntityTypeConfiguration<InitiativeProject>
{
    public void Configure(EntityTypeBuilder<InitiativeProject> builder)
    {
        builder.HasKey(e => new { e.InitiativeId, e.ProjectId });

        builder.HasOne(e => e.Initiative).WithMany(e => e.InitiativeProjects).HasForeignKey(e => e.InitiativeId);
        builder.HasOne(e => e.Project).WithMany(e => e.InitiativeProjects).HasForeignKey(e => e.ProjectId);
    }
}
