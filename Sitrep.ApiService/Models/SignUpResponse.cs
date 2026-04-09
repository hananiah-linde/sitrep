namespace Sitrep.ApiService.Models;

public record OnboardingRequest(string WorkspaceName);

public record OnboardingResponse(Guid UserId, string Email, string WorkspaceSlug);

public record UserProfileResponse(
    Guid Id,
    string Email,
    string DisplayName,
    string? AvatarUrl,
    List<WorkspaceSummary> Workspaces
);

public record WorkspaceSummary(Guid Id, string Name, string Slug, string Role);
