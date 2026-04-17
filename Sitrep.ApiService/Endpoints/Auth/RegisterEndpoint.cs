using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sitrep.ApiService.Interfaces;
using Sitrep.ApiService.Requests;
using Sitrep.ApiService.Responses;
using Sitrep.ApiService.Utils;
using Sitrep.Data;
using Sitrep.Data.Entities;
using Sitrep.Data.Enums;

namespace Sitrep.ApiService.Endpoints.Auth;

public class RegisterEndpoint(
    AppDbContext db,
    UserManager<User> userManager,
    ITokenService tokenService) : Endpoint<RegisterRequest, AuthResponse>
{
    public override void Configure()
    {
        Post("/auth/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
    {
        var slug = SlugHelper.Slugify(req.WorkspaceName);
        var slugTaken = await db.Workspaces
            .AnyAsync(w => w.Slug == slug, ct);

        if (slugTaken)
        {
            AddError(r => r.WorkspaceName, "A workspace with this name already exists.");
            await SendErrorsAsync(409, ct);
            return;
        }

        var emailExists = await db.Users
            .AnyAsync(u => u.Email == req.Email, ct);

        if (emailExists)
        {
            AddError(r => r.Email, "An account with this email already exists.");
            await SendErrorsAsync(409, ct);
            return;
        }

        var user = new User
        {
            UserName = req.Email,
            Email = req.Email
        };

        var result = await userManager.CreateAsync(user, req.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                AddError(error.Description);
            await SendErrorsAsync(400, ct);
            return;
        }

        var workspace = new Workspace
        {
            Id = Guid.NewGuid().ToString(),
            Name = req.WorkspaceName,
            Slug = SlugHelper.Slugify(req.WorkspaceName)
        };
        db.Workspaces.Add(workspace);

        db.WorkspaceMembers.Add(new WorkspaceMember
        {
            Id = Guid.NewGuid().ToString(),
            WorkspaceId = workspace.Id,
            UserId = user.Id,
            Role = MemberRole.Owner,
            JoinedAt = DateTimeOffset.UtcNow
        });

        await db.SaveChangesAsync(ct);

        await SendAsync(tokenService.BuildAuthResponse(user), cancellation: ct);
    }
}