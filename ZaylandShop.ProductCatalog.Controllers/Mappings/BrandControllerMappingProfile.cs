using AutoMapper;
using ZaylandShop.ProductCatalog.Contracts.Models;

namespace ZaylandShop.ProductCatalog.Controllers.Mappings;

public class BrandControllerMappingProfile : Profile
{
    public BrandControllerMappingProfile()
    {
        CreateMap<Brand, Entities.Brand>(MemberList.Destination);
        
        CreateMap<Entities.Brand, Brand>(MemberList.Destination);
    }
}