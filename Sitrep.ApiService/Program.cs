using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Sitrep.ApiService.Models;
using Sitrep.Data;
using Sitrep.Data.Entities;
using Sitrep.Data.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add EF Core with PostgreSQL via Aspire integration.
builder.AddNpgsqlDbContext<AppDbContext>("sitrepdb");

// Configure Keycloak authentication.
// Use the HTTP endpoint (pinned to port 8080) so the issuer is consistent
// between the frontend and API regardless of Aspire's HTTPS proxy port.
var keycloakUrl = builder.Configuration["services:keycloak:http:0"]
                  ?? builder.Configuration["services:keycloak:https:0"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"{keycloakUrl}/realms/sitrep";
        options.Audience = "sitrep-api";
        options.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
        options.TokenValidationParameters.ValidateIssuer = true;
    });

builder.Services.AddAuthorization();

// Configure CORS for frontend.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Apply pending migrations on startup.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "API service is running.");

// Returns the current user's profile, or 404 if no DB user exists yet.
app.MapGet("/api/me", async (ClaimsPrincipal principal, AppDbContext db, CancellationToken ct) =>
{
    var userId = GetUserId(principal);
    if (userId is null)
        return Results.Unauthorized();

    var user = await db.Users
        .Include(u => u.WorkspaceMemberships)
            .ThenInclude(wm => wm.Workspace)
        .FirstOrDefaultAsync(u => u.Id == userId, ct);

    if (user is null)
        return Results.NotFound();

    return Results.Ok(new UserProfileResponse(
        user.Id,
        user.Email,
        user.DisplayName,
        user.AvatarUrl,
        user.WorkspaceMemberships.Select(wm => new WorkspaceSummary(
            wm.Workspace.Id,
            wm.Workspace.Name,
            wm.Workspace.Slug,
            wm.Role.ToString()
        )).ToList()
    ));
})
.RequireAuthorization();

// Creates the User record in DB (from JWT claims) and their first workspace.
app.MapPost("/api/onboarding", async (OnboardingRequest request, ClaimsPrincipal principal, AppDbContext db, CancellationToken ct) =>
{
    var userId = GetUserId(principal);
    if (userId is null)
        return Results.Unauthorized();

    // Validate
    if (string.IsNullOrWhiteSpace(request.WorkspaceName))
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["workspaceName"] = ["Workspace name is required."]
        });

    // Check if user already exists in DB
    if (await db.Users.AnyAsync(u => u.Id == userId, ct))
        return Results.Conflict(new { message = "User already onboarded." });

    // Extract claims from JWT
    var email = principal.FindFirstValue(ClaimTypes.Email)
                ?? principal.FindFirstValue("email")
                ?? "";
    var name = principal.FindFirstValue("name")
               ?? principal.FindFirstValue(ClaimTypes.Name)
               ?? email;

    // Generate slug
    var slug = GenerateSlug(request.WorkspaceName);
    if (await db.Workspaces.AnyAsync(w => w.Slug == slug, ct))
    {
        slug = $"{slug}-{Guid.NewGuid().ToString("N")[..6]}";
    }

    var user = new User
    {
        Id = userId.Value,
        Email = email,
        DisplayName = name,
    };

    var workspace = new Workspace
    {
        Id = Guid.NewGuid(),
        Name = request.WorkspaceName,
        Slug = slug,
    };

    var membership = new WorkspaceMember
    {
        Id = Guid.NewGuid(),
        WorkspaceId = workspace.Id,
        UserId = user.Id,
        Role = MemberRole.Owner,
        JoinedAt = DateTimeOffset.UtcNow,
    };

    db.Users.Add(user);
    db.Workspaces.Add(workspace);
    db.WorkspaceMembers.Add(membership);
    await db.SaveChangesAsync(ct);

    return Results.Created($"/api/workspaces/{slug}", new OnboardingResponse(user.Id, email, slug));
})
.RequireAuthorization();

app.MapDefaultEndpoints();

app.Run();

static Guid? GetUserId(ClaimsPrincipal principal)
{
    var sub = principal.FindFirstValue(ClaimTypes.NameIdentifier)
              ?? principal.FindFirstValue("sub");
    return Guid.TryParse(sub, out var id) ? id : null;
}

static string GenerateSlug(string input)
{
    var slug = input.ToLowerInvariant().Trim();
    slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
    slug = Regex.Replace(slug, @"[\s]+", "-");
    slug = Regex.Replace(slug, @"-+", "-");
    slug = slug.Trim('-');
    return slug;
}
