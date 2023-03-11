using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Entities;
using ZaylandShop.ProductCatalog.Repositories;

namespace ZaylandShop.ProductCatalog.Services;

public class ColorService : IColorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IColorRepository _colorRepository;

    public ColorService(IUnitOfWork unitOfWork, IColorRepository colorRepository)
    {
        _unitOfWork = unitOfWork;
        _colorRepository = colorRepository;
    }

    public async Task AddColorAsync(ProductColor color)
    {
        await _colorRepository.AddAsync(color);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<ICollection<ProductColor>> GetAllColorsAsync()
    {
        var colors = await _colorRepository.GetAllAsync();
        return colors.ToList();
    }
}