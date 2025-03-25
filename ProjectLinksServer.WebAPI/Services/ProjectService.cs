using AutoMapper;
using ED.Result;
using GenericFileService.Files;
using ProjectLinksServer.WebAPI.DTOs.Project;
using ProjectLinksServer.WebAPI.Models;
using ProjectLinksServer.WebAPI.Repositories;

namespace ProjectLinksServer.WebAPI.Services;

public sealed class ProjectService(
    IProjectRepository projectRepository,
    IMapper mapper) : IProjectService
{
    public async Task<Result<string>> Create(CreateProjectDto request, CancellationToken cancellationToken)
    {
        string image = "";
        if (request.Image is null)
        {
            image = "";
        }
        if (request.Image is not null)
        {
            image = FileService.FileSaveToServer(request.Image,"wwwroot/Images");
        }

        Project project = mapper.Map<Project>(request);
        project.Image = image;
        project.ListNumber = 0;
        project.CreatedAt = DateTime.Now;
        if (request.Links != null && request.Links.Any())
        {
            project.Links = request
                .Links
                .Select(x => new Link
                    {
                        Title = x.Title,
                        Url = x.Url,
                        Project = project,
                        CreatedAt = DateTime.Now
                })
                .ToList();
        }
        return await projectRepository.Create(project, cancellationToken);
    }

    public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
    {
        return await projectRepository.Delete(id, cancellationToken);
    }

    public async Task<Result<Project>> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await projectRepository.GetById(id, cancellationToken);
    }

    public Task<Result<string>> Update(UpdateProjectDto request, CancellationToken cancellationToken)
    {
        Project? project = projectRepository.GetById(request.Id);
        if (project is null)
        {
            return Task.FromResult(Result<string>.Failure("Project not found"));
        }

        string image = "";
        if (request.Image is null)
        {
            image = project.Image!;
        }
        if (request.Image is not null)
        {
            image = FileService.FileSaveToServer(request.Image, "wwwroot/Images");
            FileService.FileDeleteToServer("wwwroot/Images/" + project.Image);
        }

        mapper.Map(request, project);
        project.Image = image;
        project.UpdatedAt = DateTime.Now;
        return projectRepository.Update(project, cancellationToken);
    }
}
