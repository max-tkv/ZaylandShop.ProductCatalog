using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Services;

public class BrandService : IBrandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBrandRepository _brandRepository;

    public BrandService(IUnitOfWork unitOfWork, IBrandRepository brandRepository)
    {
        _unitOfWork = unitOfWork;
        _brandRepository = brandRepository;
    }

    public async Task AddBrandAsync(Brand brand)
    {
        await _brandRepository.AddAsync(brand);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<ICollection<Brand>> GetAllBrandsAsync()
    {
        var brands = await _brandRepository.GetAllAsync();
        return brands.ToList();
    }
}