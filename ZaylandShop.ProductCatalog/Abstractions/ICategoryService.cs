using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Abstractions;

public interface ICategoryService
{
    Task AddCategoryAsync(Category category);
    Task<ICollection<Category>> GetAllCategoriesAsync();
}