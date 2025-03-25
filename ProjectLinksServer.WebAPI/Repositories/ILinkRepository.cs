using ED.Result;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Repositories;

public interface ILinkRepository
{
    public Task<Result<string>> Create(Link link, CancellationToken cancellationToken);
    public Task<Result<string>> Update(Link link, CancellationToken cancellationToken);
    public Task<Result<List<Link>>> GetAllByProjectId(Guid projectId, CancellationToken cancellationToken);
    public Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken); 
    public Link? GetById(Guid id);
}
