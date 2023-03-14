using Microsoft.EntityFrameworkCore;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories;

public class ColorRepository : Repository<ProductColor>, IColorRepository
{
    public ColorRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<ProductColor?> GetByIdAsync(long id) =>
        await _dbSet.AsNoTracking()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
}