using Microsoft.EntityFrameworkCore;
using Sitrep.Data.Entities;

namespace Sitrep.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Workspace> Workspaces => Set<Workspace>();
    public DbSet<User> Users => Set<User>();
    public DbSet<WorkspaceMember> WorkspaceMembers => Set<WorkspaceMember>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
    public DbSet<Workflow> Workflows => Set<Workflow>();
    public DbSet<WorkflowState> WorkflowStates => Set<WorkflowState>();
    public DbSet<Label> Labels => Set<Label>();
    public DbSet<Issue> Issues => Set<Issue>();
    public DbSet<IssueRelation> IssueRelations => Set<IssueRelation>();
    public DbSet<IssueLabel> IssueLabels => Set<IssueLabel>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Reaction> Reactions => Set<Reaction>();
    public DbSet<Attachment> Attachments => Set<Attachment>();
    public DbSet<IssueActivity> IssueActivities => Set<IssueActivity>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectMember> ProjectMembers => Set<ProjectMember>();
    public DbSet<Milestone> Milestones => Set<Milestone>();
    public DbSet<Cycle> Cycles => Set<Cycle>();
    public DbSet<CycleIssue> CycleIssues => Set<CycleIssue>();
    public DbSet<Initiative> Initiatives => Set<Initiative>();
    public DbSet<InitiativeProject> InitiativeProjects => Set<InitiativeProject>();
    public DbSet<IssueView> IssueViews => Set<IssueView>();
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var now = DateTimeOffset.UtcNow;

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Metadata.FindProperty("CreatedAt") is not null)
                    entry.Property("CreatedAt").CurrentValue = now;
                if (entry.Metadata.FindProperty("UpdatedAt") is not null)
                    entry.Property("UpdatedAt").CurrentValue = now;
            }
            else if (entry.State == EntityState.Modified)
            {
                if (entry.Metadata.FindProperty("UpdatedAt") is not null)
                    entry.Property("UpdatedAt").CurrentValue = now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
