namespace ProjectLinksServer.WebAPI.DTOs.Link;

public sealed record UpdateLinkDto(
    Guid Id,
    string Title,
    string Url);