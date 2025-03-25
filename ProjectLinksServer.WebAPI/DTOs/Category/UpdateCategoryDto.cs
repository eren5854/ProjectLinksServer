namespace ProjectLinksServer.WebAPI.DTOs.Category;

public sealed record UpdateCategoryDto(
    Guid Id,
    string CategoryName,
    string? Description,
    Guid? MainCategoryId);
