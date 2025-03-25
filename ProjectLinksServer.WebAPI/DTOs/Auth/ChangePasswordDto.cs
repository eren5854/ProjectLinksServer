namespace ProjectLinksServer.WebAPI.DTOs.Auth;

public sealed record ChangePasswordDto(
    Guid UserId,
    string CurrentPassword,
    string NewPassword);
