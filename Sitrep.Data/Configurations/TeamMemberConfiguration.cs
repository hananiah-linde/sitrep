using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
{
    public void Configure(EntityTypeBuilder<TeamMember> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Role).HasConversion<string>().HasColumnType("text");

        builder.HasIndex(e => new { e.TeamId, e.UserId }).IsUnique();

        builder.HasOne(e => e.Team).WithMany(e => e.Members).HasForeignKey(e => e.TeamId);
        builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
    }
}
