using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Models;

namespace ZaylandShop.ProductCatalog.Abstractions;

public interface IProductService
{
    Task AddProductAsync(Product product);
    
    Task<Product?> GetByIdAsync(long id);
    
    Task<ICollection<Product>> GetAllProductsAsync();

    Task<ICollection<Product>> GetProductByFilerAsync(ProductFilter productFilter);
}