using ED.Result;
using Microsoft.EntityFrameworkCore;
using ProjectLinksServer.WebAPI.Context;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Repositories;

public sealed class CategoryRepository(
    ApplicationDbContext context) : ICategoryRepository
{
    public async Task<Result<string>> Create(Category category, CancellationToken cancellationToken)
    {
        bool isCategoryExist = await context
            .Categories
            .AnyAsync(a => a.CategoryName == category.CategoryName, cancellationToken);
        if (isCategoryExist)
        {
            return Result<string>.Failure("Category already exists");
        }
        await context.Categories.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Category created successfully");
    }

    public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
    {
        Category? category = await context
            .Categories
            .SingleOrDefaultAsync(s => s.Id == id, cancellationToken);
        if (category is null)
        {
            return Result<string>.Failure("Category not found");
        }

        context.Categories.Remove(category);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Category deleted successfully");
    }

    public async Task<Result<List<Category>>> GetAllByUserId(Guid userId, CancellationToken cancellationToken)
    {
        List<Category> categories = await context
            .Categories
            .Where(w => w.MainCategoryId == null)
            .Include(i => i.SubCategories)
            .ThenInclude(t => t.Projects)
            .ThenInclude(t => t.Links)
            .Include(i => i.Projects)
            .ToListAsync(cancellationToken);

        return Result<List<Category>>.Succeed(categories);
    }

    public async Task<Result<List<Category>>> GetAll(CancellationToken cancellationToken)
    {
        List<Category> categories = await context
             .Categories
             .Where(w => w.MainCategoryId == null)
             .Include(i => i.SubCategories)
             .ThenInclude(t => t.Projects)
             .ThenInclude(t => t.Links)
             .Include(i => i.Projects)
             .ToListAsync(cancellationToken);
        return Result<List<Category>>.Succeed(categories);
    }

    public Category? GetById(Guid id)
    {
        return context.Categories.Find(id);
    }

    public async Task<Result<string>> Update(Category category, CancellationToken cancellationToken)
    {
        context.Categories.Update(category);
        await context.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Category updated successfully");
    }
}
