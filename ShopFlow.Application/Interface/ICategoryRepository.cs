using ShopFlow.Domain.Entity;

namespace ShopFlow.Application.Interface;

public interface ICategoryRepository
{
    Task<IReadOnlyList<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(Guid categoryId);
    Task AddAsync(Category category);
}