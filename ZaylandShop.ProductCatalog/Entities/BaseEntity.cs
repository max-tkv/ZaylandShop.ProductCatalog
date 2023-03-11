using System.Text.Json.Serialization;

namespace ZaylandShop.ProductCatalog.Entities;

public class BaseEntity
{
    [JsonIgnore] 
    public long Id { get; set; }

    [JsonIgnore] 
    public DateTime CreatedAt { get; set; }

    [JsonIgnore] 
    public DateTime UpdatedDateTime { get; set; }
}