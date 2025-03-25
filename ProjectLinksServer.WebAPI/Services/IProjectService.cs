using ED.Result;
using ProjectLinksServer.WebAPI.DTOs.Project;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Services;

public interface IProjectService
{
    public Task<Result<string>> Create(CreateProjectDto request, CancellationToken cancellationToken);
    public Task<Result<string>> Update(UpdateProjectDto request, CancellationToken cancellationToken);
    public Task<Result<Project>> GetById(Guid id, CancellationToken cancellationToken);
    public Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
}
