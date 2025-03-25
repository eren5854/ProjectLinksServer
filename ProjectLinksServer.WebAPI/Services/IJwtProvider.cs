using ProjectLinksServer.WebAPI.DTOs.Auth;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Services;

public interface IJwtProvider
{
    Task<LoginResponseDto> CreateToken(AppUser user);
}
