namespace Sitrep.ApiService.Requests;

public record RegisterRequest(string Email, string Password, string WorkspaceName);