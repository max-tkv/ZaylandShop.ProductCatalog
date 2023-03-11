using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Abstractions;

public interface IProductService
{
    Task AddProductAsync(Product product);
    Task<ICollection<Product>> GetAllProductsAsync();
}