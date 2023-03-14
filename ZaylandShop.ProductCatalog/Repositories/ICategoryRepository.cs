using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetByIdAsync(long id);
}