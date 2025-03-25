using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectLinksServer.WebAPI.Abstractions;
using ProjectLinksServer.WebAPI.DTOs.Project;
using ProjectLinksServer.WebAPI.Services;

namespace ProjectLinksServer.WebAPI.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
public sealed class ProjectsController(
    IProjectService projectService) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateProjectDto request, CancellationToken cancellationToken)
    {
        var response = await projectService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var response = await projectService.GetById(id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromForm]UpdateProjectDto request, CancellationToken cancellationToken)
    {
        var response = await projectService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var response = await projectService.Delete(id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
