using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Abstractions;

public interface IUnitOfWork : IDisposable
{
    public IRepository<Product> Products { get; }
    
    public IRepository<Category> Categories { get; }
    
    public IRepository<ProductFile> Files { get; }

    public IRepository<ProductColor> Colors { get; }

    public IRepository<Brand> Brands { get; }
    
    Task BeginTransactionAsync();
    
    Task CommitTransactionAsync();
    
    Task RollbackTransactionAsync();
    
    Task SaveChangesAsync();
}