using Microsoft.EntityFrameworkCore;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories;

public class FileRepository : Repository<ProductFile>, IFileRepository
{
    public FileRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<ProductFile?> GetByIdAsync(long id) =>
        await _dbSet.AsNoTracking()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
}