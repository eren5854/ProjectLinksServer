using ProjectLinksServer.WebAPI.DTOs.Link;

namespace ProjectLinksServer.WebAPI.DTOs.Project;

public sealed record UpdateProjectDto(
    Guid Id,
    string Title,
    string? Description,
    int ListNumber,
    IFormFile? Image,
    Guid CategoryId);