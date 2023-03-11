using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Utils.ApiResponse;

namespace ZaylandShop.ProductCatalog.Controllers.Api.V1;

[ApiVersion("1")]
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="productService"></param>
    public ProductController(IMapper mapper, IProductService productService)
    {
        _mapper = mapper;
        _productService = productService;
    }

    /// <summary>
    /// ВО
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponseResult<Contracts.Models.Product.Product>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse))]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<ApiResponseResult<Contracts.Models.Product.Product>> GetProduct([FromRoute] long id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        var dto = _mapper.Map<Contracts.Models.Product.Product>(product);
        return ApiResponse.CreateSuccess(dto);
    }
}