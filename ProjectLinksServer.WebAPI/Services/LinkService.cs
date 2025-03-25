using AutoMapper;
using ED.Result;
using ProjectLinksServer.WebAPI.DTOs.Link;
using ProjectLinksServer.WebAPI.Models;
using ProjectLinksServer.WebAPI.Repositories;

namespace ProjectLinksServer.WebAPI.Services;

public sealed class LinkService(
    ILinkRepository linkRepository,
    IMapper mapper) : ILinkService
{
    public async Task<Result<string>> Create(CreateLinkDto request, CancellationToken cancellationToken)
    {
        Link link = mapper.Map<Link>(request);
        link.CreatedAt = DateTime.Now;

        return await linkRepository.Create(link, cancellationToken);
    }

    public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
    {
        return await linkRepository.Delete(id, cancellationToken);
    }

    public async Task<Result<List<Link>>> GetAllByProjectId(Guid projectId, CancellationToken cancellationToken)
    {
        return await linkRepository.GetAllByProjectId(projectId, cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateLinkDto request, CancellationToken cancellationToken)
    {
        Link? link = linkRepository.GetById(request.Id);
        if (link is null)
        {
            return Result<string>.Failure("Link not found");
        }

        mapper.Map(request, link);
        link.UpdatedAt = DateTime.Now;
        return await linkRepository.Update(link, cancellationToken);
    }
}
