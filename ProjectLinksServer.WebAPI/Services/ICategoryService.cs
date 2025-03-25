using ED.Result;
using ProjectLinksServer.WebAPI.DTOs.Category;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Services;

public interface ICategoryService
{
    public Task<Result<string>> Create(CreateCategoryDto request, CancellationToken cancellationToken);
    public Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
    public Task<Result<string>> Update(UpdateCategoryDto request, CancellationToken cancellationToken);
    public Task<Result<List<Category>>> GetAllByUserId(Guid userId, CancellationToken cancellationToken);
    public Task<Result<List<Category>>> GetAll(CancellationToken cancellationToken);
}
