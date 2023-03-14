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
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="productService"></param>
    public CategoryController(IMapper mapper, ICategoryService categoryService)
    {
        _mapper = mapper;
        _categoryService = categoryService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponseResult<Category>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse))]
    [Consumes("application/json")]
    [Produces("application/json")]
    public async Task<ApiResponseResult<Category>> GetCategory([FromRoute] long id)
    {
        var product = await _categoryService.GetByIdAsync(id);
        var dto = _mapper.Map<Category>(product);
        
        return ApiResponse.CreateSuccess(dto);
    }
}