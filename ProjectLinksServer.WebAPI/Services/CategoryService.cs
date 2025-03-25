using AutoMapper;
using ED.Result;
using ProjectLinksServer.WebAPI.DTOs.Category;
using ProjectLinksServer.WebAPI.Models;
using ProjectLinksServer.WebAPI.Repositories;

namespace ProjectLinksServer.WebAPI.Services;

public sealed class CategoryService(
    ICategoryRepository categoryRepository,
    IMapper mapper) : ICategoryService
{
    public async Task<Result<string>> Create(CreateCategoryDto request, CancellationToken cancellationToken)
    {
        Category category = mapper.Map<Category>(request);
        category.CreatedAt = DateTime.Now;
        return await categoryRepository.Create(category, cancellationToken);
    }

    public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
    {
        return await categoryRepository.Delete(id, cancellationToken);
    }

    public async Task<Result<List<Category>>> GetAll(CancellationToken cancellationToken)
    {
        return await categoryRepository.GetAll(cancellationToken);
    }

    public async Task<Result<List<Category>>> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return await categoryRepository.GetAllByUserId(userId, cancellationToken);
    }

    public async Task<Result<string>> Update(UpdateCategoryDto request, CancellationToken cancellationToken)
    {
        Category? category = categoryRepository.GetById(request.Id);
        if (category is null)
        {
            return Result<string>.Failure("Category not found");
        }

        mapper.Map(request, category);
        category.UpdatedAt = DateTime.Now;

        return await categoryRepository.Update(category, cancellationToken);
    }
}
