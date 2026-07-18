using Microsoft.EntityFrameworkCore;
using ShopFlow.Domain.Entity;

namespace ShopFlow.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Product>  Products { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)                                                                                                                
    {                                                                                                                                                                                 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);                                                                                                  
    }
    
}