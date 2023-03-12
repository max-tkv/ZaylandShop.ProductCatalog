using System.Linq.Expressions;
using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Models;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task AddProductAsync(Product product)
    {
        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<Product> GetProductByIdAsync(long id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<ICollection<Product>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.ToList();
    }

    public async Task<ICollection<Product>> GetProductByFilerAsync(ProductFilter productFilter)
    {
        Expression<Func<Product, bool>> filter = p =>
            (!productFilter.BrandId.HasValue || p.BrandId == productFilter.BrandId) &&
            (!productFilter.ColorId.HasValue || p.ProductColorId == productFilter.ColorId) &&
            (productFilter.CategoryIds == null || !productFilter.CategoryIds.Any() || 
             productFilter.CategoryIds.Any(x => p.Categories.Select(y => y.Id).Contains(x)));
        
        var products = await _productRepository.GetByFilerAsync(
            filter, 
            productFilter.Page, 
            productFilter.Size);
        

        return products?.ToList() ?? new List<Product>();
    }
}