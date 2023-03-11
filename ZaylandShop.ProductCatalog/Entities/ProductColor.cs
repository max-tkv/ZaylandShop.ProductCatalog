namespace ZaylandShop.ProductCatalog.Entities;

public class ProductColor : BaseEntity
{
    public string Name { get; set; }
    
    public string Hex { get; set; }
    
    public ICollection<Product> Products { get; set; }
}