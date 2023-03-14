using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Models;

namespace ZaylandShop.ProductCatalog.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddProductAsync(Product product)
    {
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Product?> GetByIdAsync(long id) =>
        await _unitOfWork.Products.GetByIdAsync(id);
    
    public async Task<ICollection<Product>> GetAllProductsAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        return products.ToList();
    }

    public async Task<ICollection<Product>> GetProductByFilerAsync(ProductFilter productFilter) =>
        await _unitOfWork.Products.GetByFilerAsync(productFilter);
}