using AutoMapper;
using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Controllers.Mappings;

public class ProductControllerMappingProfile : Profile
{
    public ProductControllerMappingProfile()
    {
        CreateMap<Contracts.Models.Product.Product, Product>(MemberList.Destination);
        
        CreateMap<Product, Contracts.Models.Product.Product>(MemberList.Destination);
    }
}