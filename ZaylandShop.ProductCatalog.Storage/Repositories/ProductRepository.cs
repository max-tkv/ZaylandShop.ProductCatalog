using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories;

public class ProductRepository : Repository<Entities.Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}