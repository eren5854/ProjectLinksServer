using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectLinksServer.WebAPI.Abstractions;
using ProjectLinksServer.WebAPI.DTOs.Category;
using ProjectLinksServer.WebAPI.Services;

namespace ProjectLinksServer.WebAPI.Controllers;

public sealed class CategoriesController(
    ICategoryService categoryService) : ApiController
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto request, CancellationToken cancellationToken)
    {
        var response = await categoryService.Create(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await categoryService.GetAll(cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
    {
        var response = await categoryService.GetAllByUserId(userId, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryDto request, CancellationToken cancellationToken)
    {
        var response = await categoryService.Update(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]
    [HttpGet]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var response = await categoryService.Delete(id, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
