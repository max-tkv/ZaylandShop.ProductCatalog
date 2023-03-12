using AutoMapper;
using File = ZaylandShop.ProductCatalog.Contracts.Models.File;

namespace ZaylandShop.ProductCatalog.Controllers.Mappings;

public class FileControllerMappingProfile : Profile
{
    public FileControllerMappingProfile()
    {
        CreateMap<File, Entities.ProductFile>(MemberList.Destination);
        
        CreateMap<Entities.ProductFile, File>(MemberList.Destination);
    }
}