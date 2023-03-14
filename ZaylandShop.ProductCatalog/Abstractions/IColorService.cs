using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Abstractions;

public interface IColorService
{
    Task AddColorAsync(ProductColor color);
    Task<ICollection<ProductColor>> GetAllColorsAsync();
    Task<ProductColor?> GetByIdAsync(long id);
}