using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class IssueActivityConfiguration : IEntityTypeConfiguration<IssueActivity>
{
    public void Configure(EntityTypeBuilder<IssueActivity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Type).HasColumnType("text");
        builder.Property(e => e.FromValue).HasColumnType("text");
        builder.Property(e => e.ToValue).HasColumnType("text");
        builder.Property(e => e.Metadata).HasColumnType("jsonb");

        builder.HasIndex(e => e.IssueId);
        builder.HasIndex(e => e.ActorId);

        builder.HasOne(e => e.Issue).WithMany(e => e.Activities).HasForeignKey(e => e.IssueId);
        builder.HasOne(e => e.Actor).WithMany().HasForeignKey(e => e.ActorId);
    }
}
