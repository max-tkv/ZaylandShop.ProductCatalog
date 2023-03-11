using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Storage.Repositories;

public class FileRepository : Repository<Entities.ProductFile>, IFileRepository
{
    public FileRepository(AppDbContext context) : base(context)
    {
    }
}