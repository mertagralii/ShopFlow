using ShopFlow.Domain.Entity;

namespace ShopFlow.Application.Interface;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Product>> GetAllAsync(); // IReadOnyList sadece okuma yapılmasınan yarıyor.
    Task AddAsync(Product product);
    
}