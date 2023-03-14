using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Services;

public class BrandService : IBrandService
{
    private readonly IUnitOfWork _unitOfWork;

    public BrandService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddBrandAsync(Brand brand)
    {
        await _unitOfWork.Brands.AddAsync(brand);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<ICollection<Brand>> GetAllBrandsAsync()
    {
        var brands = await _unitOfWork.Brands.GetAllAsync();
        return brands.ToList();
    }

    public async Task<Brand?> GetByIdAsync(long id) =>
        await _unitOfWork.Brands.GetByIdAsync(id);
}