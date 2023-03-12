using AutoMapper;
using ZaylandShop.ProductCatalog.Contracts.Models.Product;
using ZaylandShop.ProductCatalog.Models;

namespace ZaylandShop.ProductCatalog.Controllers.Mappings;

public class ProductControllerMappingProfile : Profile
{
    public ProductControllerMappingProfile()
    {
        CreateMap<Product, Entities.Product>(MemberList.Destination);
        
        CreateMap<Entities.Product, Product>(MemberList.Destination);
        
        CreateMap<GetProductsRequest, ProductFilter>(MemberList.Destination);
    }
}