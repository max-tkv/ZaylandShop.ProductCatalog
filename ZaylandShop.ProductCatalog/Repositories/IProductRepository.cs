using ZaylandShop.ProductCatalog.Models;

namespace ZaylandShop.ProductCatalog.Repositories;

public interface IProductRepository : IRepository<Entities.Product>
{
    Task<ICollection<Entities.Product>> GetByFilerAsync(ProductFilter productFile);

    Task<Entities.Product?> GetByIdAsync(long id);
}