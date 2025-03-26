using ProjectLinksServer.WebAPI.DTOs.Link;

namespace ProjectLinksServer.WebAPI.DTOs.Project;

public sealed record CreateProjectDto(
    string Title,
    string? Description,
    int? ListNumber,
    IFormFile? Image,
    Guid CategoryId,
    List<CreateLinkDto>? Links);