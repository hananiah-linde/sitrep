using Sitrep.ApiService.Responses;
using Sitrep.Data.Entities;

namespace Sitrep.ApiService.Interfaces;

public interface ITokenService
{
    AuthResponse BuildAuthResponse(User user);
}