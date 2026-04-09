using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sitrep.Data.Entities;

namespace Sitrep.Data.Configurations;

public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title).HasColumnType("text");
        builder.Property(e => e.Description).HasColumnType("text");
        builder.Property(e => e.Priority).HasConversion<string>().HasColumnType("text");

        builder.HasIndex(e => new { e.TeamId, e.Number }).IsUnique();
        builder.HasIndex(e => e.TeamId);
        builder.HasIndex(e => e.AssigneeId);
        builder.HasIndex(e => e.WorkflowStateId);
        builder.HasIndex(e => e.ProjectId);

        builder.HasOne(e => e.Team).WithMany(e => e.Issues).HasForeignKey(e => e.TeamId);
        builder.HasOne(e => e.WorkflowState).WithMany(e => e.Issues).HasForeignKey(e => e.WorkflowStateId);
        builder.HasOne(e => e.Assignee).WithMany(e => e.AssignedIssues).HasForeignKey(e => e.AssigneeId);
        builder.HasOne(e => e.CreatedBy).WithMany().HasForeignKey(e => e.CreatedById).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.ParentIssue).WithMany(e => e.SubIssues).HasForeignKey(e => e.ParentIssueId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Project).WithMany(e => e.Issues).HasForeignKey(e => e.ProjectId);
        builder.HasOne(e => e.Milestone).WithMany(e => e.Issues).HasForeignKey(e => e.MilestoneId);

        builder.HasQueryFilter(e => e.ArchivedAt == null);
    }
}
