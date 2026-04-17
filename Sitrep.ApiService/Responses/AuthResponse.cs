namespace Sitrep.ApiService.Responses;

public record AuthResponse(string Token, DateTimeOffset ExpiresAt, string UserId, string Email);