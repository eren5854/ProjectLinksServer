using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectLinksServer.WebAPI.Abstractions;
using ProjectLinksServer.WebAPI.DTOs.Link;
using ProjectLinksServer.WebAPI.Services;

namespace ProjectLinksServer.WebAPI.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class LinksController(
    ILinkService linkService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateLinkDto request, CancellationToken cancellationToken)
    {
        var response = await linkService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllByProjectId(Guid projectId, CancellationToken cancellationToken)
    {
        var response = await linkService.GetAllByProjectId(projectId, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateLinkDto request, CancellationToken cancellationToken)
    {
        var response = await linkService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var response = await linkService.Delete(id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
