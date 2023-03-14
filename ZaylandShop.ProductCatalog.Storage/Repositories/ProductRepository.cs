using Microsoft.EntityFrameworkCore;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Models;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<ICollection<Product>> GetByFilerAsync(ProductFilter filter)
    {
        var query = _dbSet.AsNoTracking();
        if (filter.BrandId.HasValue)
        {
            query = query.Where(p => p.BrandId == filter.BrandId);
        }

        if (filter.ColorId.HasValue)
        {
            query = query.Where(p => p.ProductColorId == filter.ColorId);
        }

        if (filter.CategoryIds != null && filter.CategoryIds.Any())
        {
            query = query.Where(p => p.Categories.Any(c => filter.CategoryIds.Contains(c.Id)));
        }

        return await query
            .Include(x => x.Categories)
            .Include(x => x.Brand)
            .Include(x => x.ProductColor)
            .Include(x => x.Files)
            .Skip((filter.Page - 1) * filter.Size)
            .Take(filter.Size)
            .ToListAsync();
    }

    public async Task<Product> GetByIdAsync(long id) =>
        await _dbSet.AsNoTracking()
            .Where(x => x.Id == id)
            .Include(x => x.Categories)
            .Include(x => x.Brand)
            .Include(x => x.ProductColor)
            .Include(x => x.Files)
            .SingleOrDefaultAsync();
}