namespace ProjectLinksServer.WebAPI.DTOs.Category;

public sealed record CreateCategoryDto(
    string CategoryName,
    string? Description,
    Guid? MainCategoryId,
    Guid AppUserId);
