using AutoMapper;
using ZaylandShop.ProductCatalog.Contracts.Models;

namespace ZaylandShop.ProductCatalog.Controllers.Mappings;

public class CategoryControllerMappingProfile : Profile
{
    public CategoryControllerMappingProfile()
    {
        CreateMap<Category, Entities.Category>(MemberList.Destination);
        
        CreateMap<Entities.Category, Category>(MemberList.Destination);
    }
}