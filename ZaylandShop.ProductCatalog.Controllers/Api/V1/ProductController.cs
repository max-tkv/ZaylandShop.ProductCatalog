using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZaylandShop.ProductCatalog.Abstractions;
using ZaylandShop.ProductCatalog.Contracts.Models.Product;
using ZaylandShop.ProductCatalog.Models;
using ZaylandShop.ProductCatalog.Utils.ApiResponse;

namespace ZaylandShop.ProductCatalog.Controllers.Api.V1;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
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
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponseResult<Product>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse))]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<ApiResponseResult<Product>> GetProduct([FromRoute] long id)
    {
        var product = await _productService.GetByIdAsync(id);
        var dto = _mapper.Map<Product>(product);
        
        return ApiResponse.CreateSuccess(dto);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("filter")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponseResult<ICollection<Product>>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse))]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<ApiResponseResult<ICollection<Product>>> GetProducts(
        [FromQuery] Contracts.Models.GetProductsRequest request)
    {
        var filter = _mapper.Map<ProductFilter>(request);
        var products = await _productService.GetProductByFilerAsync(filter);
        var dto = _mapper.Map<ICollection<Product>>(products);
        
        return ApiResponse.CreateSuccess(dto);
    }
}