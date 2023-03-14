using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Services;

public class ColorService : IColorService
{
    private readonly IUnitOfWork _unitOfWork;

    public ColorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddColorAsync(ProductColor color)
    {
        await _unitOfWork.Colors.AddAsync(color);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<ICollection<ProductColor>> GetAllColorsAsync()
    {
        var colors = await _unitOfWork.Colors.GetAllAsync();
        return colors.ToList();
    }
    
    public async Task<ProductColor?> GetByIdAsync(long id) =>
        await _unitOfWork.Colors.GetByIdAsync(id);
}