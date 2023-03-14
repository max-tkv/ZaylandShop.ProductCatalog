using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Repositories;

public interface IFileRepository : IRepository<ProductFile>
{
    Task<ProductFile?> GetByIdAsync(long id);
}