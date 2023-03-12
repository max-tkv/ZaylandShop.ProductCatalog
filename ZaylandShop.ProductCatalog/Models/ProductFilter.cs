namespace ZaylandShop.ProductCatalog.Models;

public class ProductFilter
{
    public ICollection<long>? CategoryIds { get; set; }
    
    public long? ColorId { get; set; }
    
    public long? BrandId { get; set; }
    
    public int Size { get; set; }
    
    public int Page { get; set; }
}