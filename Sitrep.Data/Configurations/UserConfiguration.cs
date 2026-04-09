using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Email).HasColumnType("text");
        builder.Property(e => e.DisplayName).HasColumnType("text");
        builder.Property(e => e.AvatarUrl).HasColumnType("text");

        builder.HasIndex(e => e.Email).IsUnique();
    }
}
