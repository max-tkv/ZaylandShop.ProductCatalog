using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Contracts.Models;
using ZaylandShop.ProductCatalog.Utils.ApiResponse;

namespace ZaylandShop.ProductCatalog.Controllers.Api.V1;

[ApiVersion("1")]
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public class BrandController : Controller
{
    private readonly IBrandService _brandService;
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="productService"></param>
    public BrandController(IMapper mapper, IBrandService brandService)
    {
        _mapper = mapper;
        _brandService = brandService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponseResult<Brand>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse))]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<ApiResponseResult<Brand>> GetBrand([FromRoute] long id)
    {
        var product = await _brandService.GetByIdAsync(id);
        var dto = _mapper.Map<Brand>(product);
        
        return ApiResponse.CreateSuccess(dto);
    }
}