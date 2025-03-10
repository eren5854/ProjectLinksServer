using ProjectLinksServer.WebAPI.Abstractions;
using System.Text.Json.Serialization;

namespace ProjectLinksServer.WebAPI.Models;

public sealed class Project : Entity
{
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public int ListNumber { get; set; } = 0;
    public string? Image { get; set; }

    [JsonIgnore]
    public Guid CategoryId { get; set; }
    [JsonIgnore]
    public Category Category { get; set; } = default!;

    public List<Link>? Links { get; set; }
}
