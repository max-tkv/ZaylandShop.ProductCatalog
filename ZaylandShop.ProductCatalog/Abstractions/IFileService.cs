using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Abstractions;

public interface IFileService
{
    Task AddFileAsync(ProductFile file);
    Task<ICollection<ProductFile>> GetAllFilesAsync();
    Task<ProductFile?> GetByIdAsync(long id);
}