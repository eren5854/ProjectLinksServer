using ProjectLinksServer.WebAPI.Abstractions;
using System.Text.Json.Serialization;

namespace ProjectLinksServer.WebAPI.Models;

public sealed class Category : Entity
{
    public string CategoryName { get; set; } = default!;
    public string? Description { get; set; }

    //public object? MainCategoryInfo => new
    //{
    //    MainCategoryId = MainCategoryId,
    //    MainCategoryName = MainCategory?.CategoryName,
    //    MainCategoryDescription = MainCategory?.Description
    //};

    [JsonIgnore]
    public Guid? MainCategoryId { get; set; }
    [JsonIgnore]
    public Category? MainCategory { get; set; }

    public List<Category>? SubCategories { get; set; }

    [JsonIgnore]
    public Guid AppUserId { get; set; }
    [JsonIgnore]
    public AppUser AppUser { get; set; } = default!;

    public List<Project>? Projects { get; set; }
}
