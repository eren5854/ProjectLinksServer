using ED.Result;
using ProjectLinksServer.WebAPI.DTOs.Link;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Services;

public interface ILinkService
{
    public Task<Result<string>> Create(CreateLinkDto request, CancellationToken cancellationToken);
    public Task<Result<string>> Update(UpdateLinkDto request, CancellationToken cancellationToken);
    public Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
    public Task<Result<List<Link>>> GetAllByProjectId(Guid projectId, CancellationToken cancellationToken);
}
