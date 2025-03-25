using ED.Result;
using Microsoft.EntityFrameworkCore;
using ProjectLinksServer.WebAPI.Context;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Repositories;

public sealed class LinkRepository(
    ApplicationDbContext context) : ILinkRepository
{
    public async Task<Result<string>> Create(Link link, CancellationToken cancellationToken)
    {
        await context.Links.AddAsync(link, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Link created successfully");
    }

    public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
    {
        Link? link = await context.Links.SingleOrDefaultAsync(s => s.Id == id, cancellationToken);
        if (link is null)
        {
            return Result<string>.Failure("Link not found");
        }

        context.Links.Remove(link);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Link deleted successfully");
    }

    public async Task<Result<List<Link>>> GetAllByProjectId(Guid projectId, CancellationToken cancellationToken)
    {
        List<Link> links = await context.Links.Where(w => w.ProjectId == projectId).ToListAsync(cancellationToken);
        return Result<List<Link>>.Succeed(links);
    }

    public Link? GetById(Guid id)
    {
        return context.Links.SingleOrDefault(s => s.Id == id);
    }

    public async Task<Result<string>> Update(Link link, CancellationToken cancellationToken)
    {
        context.Links.Update(link);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Link updated successfully");
    }
}
