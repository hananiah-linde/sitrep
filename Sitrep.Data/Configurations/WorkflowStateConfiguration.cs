using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class WorkflowStateConfiguration : IEntityTypeConfiguration<WorkflowState>
{
    public void Configure(EntityTypeBuilder<WorkflowState> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasColumnType("text");
        builder.Property(e => e.Category).HasConversion<string>().HasColumnType("text");
        builder.Property(e => e.Color).HasColumnType("text");
        builder.Property(e => e.Description).HasColumnType("text");

        builder.HasIndex(e => new { e.WorkflowId, e.Position });

        builder.HasOne(e => e.Workflow).WithMany(e => e.States).HasForeignKey(e => e.WorkflowId);
    }
}
