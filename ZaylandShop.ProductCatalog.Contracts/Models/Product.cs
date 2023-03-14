namespace ZaylandShop.ProductCatalog.Contracts.Models.Product;

public class Product
{
    public string Name { get; set; }

    public Color ProductColor { get; set; }

    public Brand Brand { get; set; }
    
    public decimal Price { get; set; }
    
    public string Description { get; set; }
    
    public ICollection<Category> Categories { get; set; }
    
    public ICollection<File> Files { get; set; }
}