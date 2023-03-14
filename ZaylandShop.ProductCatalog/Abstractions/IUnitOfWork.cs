using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Abstractions;

public interface IUnitOfWork : IDisposable
{
    public IProductRepository Products { get; }
    
    public ICategoryRepository Categories { get; }
    
    public IFileRepository Files { get; }

    public IColorRepository Colors { get; }

    public IBrandRepository Brands { get; }
    
    Task BeginTransactionAsync();
    
    Task CommitTransactionAsync();
    
    Task RollbackTransactionAsync();
    
    Task SaveChangesAsync();
}