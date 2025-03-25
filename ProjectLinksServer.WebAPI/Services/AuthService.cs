using ED.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectLinksServer.WebAPI.DTOs.Auth;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Services;

public sealed class AuthService(
    UserManager<AppUser> userManager,
    IJwtProvider jwtProvider) : IAuthService
{
    public async Task<Result<string>> ChangePassword(ChangePasswordDto request, CancellationToken cancellationToken)
    {
        AppUser? user = await userManager.FindByIdAsync(request.UserId.ToString());
        if (user is null)
        {
            return Result<string>.Failure("User not found");
        }

        IdentityResult result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        if (!result.Succeeded)
        {
            return Result<string>.Failure("Old password is wrong");
        }

        return Result<string>.Succeed("Password change is successful");
    }

    public async Task<Result<LoginResponseDto>> Login(LoginDto request, CancellationToken cancellationToken)
    {
        string emailOrUserName = request.EmailOrUserName.ToUpper();
        AppUser? user = await userManager
            .Users
            .Where(w => w.Email == emailOrUserName || 
                   w.UserName == emailOrUserName)
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null)
        {
            return Result<LoginResponseDto>.Failure("User not found");
        }

        bool isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
        if (!isPasswordValid)
        {
            return Result<LoginResponseDto>.Failure("Invalid password");
        }

        var loginResponse = await jwtProvider.CreateToken(user);
        return loginResponse;
    }
}
