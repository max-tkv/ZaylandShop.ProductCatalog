using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories;

public class ColorRepository : Repository<Entities.ProductColor>, IColorRepository
{
    public ColorRepository(AppDbContext context) : base(context)
    {
    }
}