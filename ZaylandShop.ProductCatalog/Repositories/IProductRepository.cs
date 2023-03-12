using System.Linq.Expressions;

namespace ZaylandShop.ProductCatalog.Repositories;

public interface IProductRepository : IRepository<Entities.Product>
{
    Task<List<Entities.Product>> GetByFilerAsync(
        Expression<Func<Entities.Product, bool>> filter, 
        int page, 
        int size);
}