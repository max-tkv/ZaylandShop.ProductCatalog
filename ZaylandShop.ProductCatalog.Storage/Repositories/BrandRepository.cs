using Microsoft.EntityFrameworkCore;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Brand?> GetByIdAsync(long id) =>
        await _dbSet.AsNoTracking()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
}