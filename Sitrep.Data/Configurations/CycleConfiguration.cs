using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class CycleConfiguration : IEntityTypeConfiguration<Cycle>
{
    public void Configure(EntityTypeBuilder<Cycle> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasColumnType("text");
        builder.Property(e => e.Number).UseIdentityAlwaysColumn();

        builder.HasIndex(e => new { e.TeamId, e.Number }).IsUnique();

        builder.HasOne(e => e.Team).WithMany(e => e.Cycles).HasForeignKey(e => e.TeamId);
    }
}
