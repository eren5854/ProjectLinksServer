using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectLinksServer.WebAPI.Abstractions;
using ProjectLinksServer.WebAPI.DTOs.Auth;
using ProjectLinksServer.WebAPI.Services;

namespace ProjectLinksServer.WebAPI.Controllers;

public sealed class AuthController(
    IAuthService authService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
    {
        var response = await authService.Login(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto request, CancellationToken cancellationToken)
    {
        var response = await authService.ChangePassword(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
