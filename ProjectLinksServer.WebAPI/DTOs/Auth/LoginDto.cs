namespace ProjectLinksServer.WebAPI.DTOs.Auth;

public sealed record LoginDto(
    string EmailOrUserName,
    string Password);
