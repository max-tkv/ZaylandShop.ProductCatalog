using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Utils.ApiResponse;

namespace ZaylandShop.ProductCatalog.Controllers.Api.V1;

[ApiVersion("1")]
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public class FileController : Controller
{
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="productService"></param>
    public FileController(IMapper mapper, IFileService fileService)
    {
        _mapper = mapper;
        _fileService = fileService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponseResult<Contracts.Models.File>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse))]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<ApiResponseResult<Contracts.Models.File>> GetColor([FromRoute] long id)
    {
        var file = await _fileService.GetByIdAsync(id);
        var dto = _mapper.Map<Contracts.Models.File>(file);
        
        return ApiResponse.CreateSuccess(dto);
    }
}