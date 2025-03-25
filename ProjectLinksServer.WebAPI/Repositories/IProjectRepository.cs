using ED.Result;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Repositories;

public interface IProjectRepository
{
    public Task<Result<string>> Create(Project project, CancellationToken cancellationToken);
    public Task<Result<string>> Update(Project project, CancellationToken cancellationToken);
    public Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
    public Task<Result<Project>> GetById(Guid id, CancellationToken cancellationToken);
    public Project? GetById(Guid id);
}
