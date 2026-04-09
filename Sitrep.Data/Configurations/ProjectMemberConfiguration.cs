using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class ProjectMemberConfiguration : IEntityTypeConfiguration<ProjectMember>
{
    public void Configure(EntityTypeBuilder<ProjectMember> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Role).HasConversion<string>().HasColumnType("text");

        builder.HasIndex(e => new { e.ProjectId, e.UserId }).IsUnique();

        builder.HasOne(e => e.Project).WithMany(e => e.Members).HasForeignKey(e => e.ProjectId);
        builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
    }
}
