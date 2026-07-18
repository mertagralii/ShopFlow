using Microsoft.EntityFrameworkCore;
using ShopFlow.Application.Interface;
using ShopFlow.Domain.Entity;
using ShopFlow.Infrastructure.Persistence;

namespace ShopFlow.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
   
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public Task AddAsync(Product product)
    {
        _dbContext.Products.Add(product);
        return _dbContext.SaveChangesAsync();
    }
}