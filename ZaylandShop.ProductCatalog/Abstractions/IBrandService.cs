using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Abstractions;

public interface IBrandService
{
    Task AddBrandAsync(Brand brand);
    Task<ICollection<Brand>> GetAllBrandsAsync();
    Task<Brand?> GetByIdAsync(long id);
}