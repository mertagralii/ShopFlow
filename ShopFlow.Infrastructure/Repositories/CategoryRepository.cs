using Microsoft.EntityFrameworkCore;
using ShopFlow.Application.Interface;
using ShopFlow.Domain.Entity;
using ShopFlow.Infrastructure.Persistence;

namespace ShopFlow.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IReadOnlyList<Category>> GetAllAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid categoryId)
    {
        return await _dbContext.Categories.FindAsync(categoryId);
    }

    public async Task AddAsync(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
    }
}