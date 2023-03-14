using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _unitOfWork.Categories.AddAsync(category);
        await _unitOfWork.SaveChangesAsync();
    }
    
    public async Task<ICollection<Category>> GetAllCategoriesAsync()
    {
        var products = await _unitOfWork.Categories.GetAllAsync();
        return products.ToList();
    }

    public async Task<Category?> GetByIdAsync(long id) =>
        await _unitOfWork.Categories.GetByIdAsync(id);
}