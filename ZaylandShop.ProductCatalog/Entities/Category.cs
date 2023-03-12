using ZaylandShop.ProductCatalog.Lookups;

namespace ZaylandShop.ProductCatalog.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    
    public Group Group { get; set; }
    
    public ICollection<Product> Products { get; set; }
}