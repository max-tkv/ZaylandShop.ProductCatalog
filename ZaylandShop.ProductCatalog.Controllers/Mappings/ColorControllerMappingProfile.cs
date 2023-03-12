using AutoMapper;
using ZaylandShop.ProductCatalog.Contracts.Models;

namespace ZaylandShop.ProductCatalog.Controllers.Mappings;

public class ColorControllerMappingProfile : Profile
{
    public ColorControllerMappingProfile()
    {
        CreateMap<Color, Entities.ProductColor>(MemberList.Destination);
        
        CreateMap<Entities.ProductColor, Color>(MemberList.Destination);
    }
}