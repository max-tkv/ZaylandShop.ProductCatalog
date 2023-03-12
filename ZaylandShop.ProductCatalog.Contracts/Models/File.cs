namespace ZaylandShop.ProductCatalog.Contracts.Models;

public class File
{
    public string FileName { get; set; }
    
    public string ContentType { get; set; }
    
    public byte[] Content { get; set; }
    
    public FileType FileType { get; set; }
    
    public long ProductId { get; set; }
}