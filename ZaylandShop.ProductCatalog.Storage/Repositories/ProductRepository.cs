using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories;

public class ProductRepository : Repository<Entities.Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<List<Entities.Product>> GetByFilerAsync(
        Expression<Func<Entities.Product, bool>> filter, int page, int size) =>
        await _dbSet.AsNoTracking()
            .Include(x => x.Categories)
            .Include(x => x.Brand)
            .Include(x => x.ProductColor)
            .Include(x => x.Files)
            .Where(filter)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
}