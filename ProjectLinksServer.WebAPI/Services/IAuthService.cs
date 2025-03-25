using ED.Result;
using ProjectLinksServer.WebAPI.DTOs.Auth;

namespace ProjectLinksServer.WebAPI.Services;

public interface IAuthService
{
    public Task<Result<LoginResponseDto>> Login(LoginDto request, CancellationToken cancellationToken);
    public Task<Result<string>> ChangePassword(ChangePasswordDto request, CancellationToken cancellationToken);
}
