using Microsoft.EntityFrameworkCore;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Category?> GetByIdAsync(long id) =>
        await _dbSet.AsNoTracking()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
}