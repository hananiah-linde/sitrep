using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class WorkspaceMemberConfiguration : IEntityTypeConfiguration<WorkspaceMember>
{
    public void Configure(EntityTypeBuilder<WorkspaceMember> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Role).HasConversion<string>().HasColumnType("text");

        builder.HasIndex(e => new { e.WorkspaceId, e.UserId }).IsUnique();

        builder.HasOne(e => e.Workspace).WithMany(e => e.Members).HasForeignKey(e => e.WorkspaceId);
        builder.HasOne(e => e.User).WithMany(e => e.WorkspaceMemberships).HasForeignKey(e => e.UserId);
    }
}
