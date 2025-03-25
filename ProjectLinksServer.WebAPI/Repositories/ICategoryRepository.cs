using ED.Result;
using ProjectLinksServer.WebAPI.Models;

namespace ProjectLinksServer.WebAPI.Repositories;

public interface ICategoryRepository
{
    public Task<Result<string>> Create(Category category, CancellationToken cancellationToken);
    public Task<Result<string>> Update(Category category, CancellationToken cancellationToken);
    public Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
    public Task<Result<List<Category>>> GetAllByUserId(Guid userId, CancellationToken cancellationToken);
    public Task<Result<List<Category>>> GetAll(CancellationToken cancellationToken);
    public Category? GetById(Guid id);
}
