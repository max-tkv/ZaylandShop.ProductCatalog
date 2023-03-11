using ZaylandShop.ProductCatalog.Lookups;

namespace ZaylandShop.ProductCatalog.Entities;

public class ProductFile : BaseEntity
{
    public string FileName { get; set; }
    
    public string ContentType { get; set; }
    
    public byte[] Content { get; set; }
    
    public FileType FileType { get; set; }
    
    public long ProductId { get; set; }
    
    public Product Product { get; set; }
}