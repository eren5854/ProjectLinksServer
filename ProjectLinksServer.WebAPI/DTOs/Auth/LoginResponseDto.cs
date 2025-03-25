namespace ProjectLinksServer.WebAPI.DTOs.Auth;

public sealed record LoginResponseDto(
    string Token,
    string RefreshToken,
    DateTime RefreshTokenExpires);
