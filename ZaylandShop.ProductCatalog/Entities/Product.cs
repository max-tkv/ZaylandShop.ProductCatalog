namespace ZaylandShop.ProductCatalog.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    
    public long ProductColorId { get; set; }
    
    public ProductColor ProductColor { get; set; }
    
    public long BrandId { get; set; }
    
    public Brand Brand { get; set; }
    
    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<Category> Categories { get; set; }
    
    public ICollection<ProductFile> Files { get; set; }
}