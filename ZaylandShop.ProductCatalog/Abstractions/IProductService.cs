using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Abstractions;

public interface IProductService
{
    Task AddProductAsync(Product product);
    
    Task<Product> GetProductByIdAsync(long id);
    
    Task<ICollection<Product>> GetAllProductsAsync();
}