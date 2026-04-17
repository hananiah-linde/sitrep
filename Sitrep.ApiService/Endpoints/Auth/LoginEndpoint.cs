using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using Sitrep.ApiService.Interfaces;
using Sitrep.ApiService.Requests;
using Sitrep.ApiService.Responses;
using Sitrep.Data.Entities;

namespace Sitrep.ApiService.Endpoints.Auth;

public class LoginEndpoint(
    UserManager<User> userManager,
    ITokenService tokenService) : Endpoint<LoginRequest, AuthResponse>
{
    public override void Configure()
    {
        Post("/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var user = await userManager.FindByEmailAsync(req.Email);
        if (user is null || !await userManager.CheckPasswordAsync(user, req.Password))
        {
            AddError("Invalid email or password.");
            await SendErrorsAsync(401, ct);
            return;
        }

        await SendAsync(tokenService.BuildAuthResponse(user), cancellation: ct);
    }
}