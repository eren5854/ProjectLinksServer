using ProjectLinksServer.WebAPI.Abstractions;
using System.Text.Json.Serialization;

namespace ProjectLinksServer.WebAPI.Models;

public sealed class Link : Entity
{
    public string Title { get; set; } = default!;
    public string Url { get; set; } = default!;

    [JsonIgnore]
    public Guid ProjectId { get; set; }
    [JsonIgnore]
    public Project Project { get; set; } = default!;
}
