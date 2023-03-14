using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Repositories;

public interface IColorRepository : IRepository<Entities.ProductColor>
{
    Task<ProductColor?> GetByIdAsync(long id);
}