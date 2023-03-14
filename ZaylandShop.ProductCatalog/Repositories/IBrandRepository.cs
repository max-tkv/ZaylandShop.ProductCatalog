using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Repositories;

public interface IBrandRepository : IRepository<Brand>
{
    Task<Brand?> GetByIdAsync(long id);
}