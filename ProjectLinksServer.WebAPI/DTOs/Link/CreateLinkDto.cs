namespace ProjectLinksServer.WebAPI.DTOs.Link;

public sealed record CreateLinkDto(
    string Title,
    string Url,
    Guid? ProjectId);