using ED.Result;
using Microsoft.EntityFrameworkCore;
using ProjectLinksServer.WebAPI.Context;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Repositories;

public sealed class ProjectRepository(
    ApplicationDbContext context) : IProjectRepository
{
    public async Task<Result<string>> Create(Project project, CancellationToken cancellationToken)
    {
        await context.Projects.AddAsync(project, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Project created successfully");
    }

    public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
    {
        Project? project = await context.Projects.SingleOrDefaultAsync(s => s.Id == id, cancellationToken);
        if (project is null)
        {
            return Result<string>.Failure("Project not found");
        }

        context.Projects.Remove(project);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Project deleted successfully");
    }

    public async Task<Result<Project>> GetById(Guid id, CancellationToken cancellationToken)
    {
        Project? project = await context
            .Projects
            .Where(w => w.Id == id)
            .Include(i => i.Links)
            .FirstOrDefaultAsync(cancellationToken);

        if (project is null)
        {
            return Result<Project>.Failure("Project not found");
        }

        return Result<Project>.Succeed(project);
    }

    public Project? GetById(Guid id)
    {
        return context.Projects.SingleOrDefault(s => s.Id == id);
    }

    public async Task<Result<string>> Update(Project project, CancellationToken cancellationToken)
    {
        context.Projects.Update(project);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Project updated successfully");
    }
}
