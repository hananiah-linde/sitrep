using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class WorkspaceConfiguration : IEntityTypeConfiguration<Workspace>
{
    public void Configure(EntityTypeBuilder<Workspace> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasColumnType("text");
        builder.Property(e => e.Slug).HasColumnType("text");
        builder.Property(e => e.LogoUrl).HasColumnType("text");

        builder.HasIndex(e => e.Slug).IsUnique();
    }
}
