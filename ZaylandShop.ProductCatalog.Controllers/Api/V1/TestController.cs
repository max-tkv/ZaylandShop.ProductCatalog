using Microsoft.AspNetCore.Mvc;
using ZaylandShop.ProductCatalog.Controllers.Models;

namespace ZaylandShop.ProductCatalog.Controllers.Api.V1;

[ApiVersion("1")]
[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public class TestController : Controller
{

    public TestController()
    {
    }

    [HttpGet]
    public IActionResult Test(string data)
    {
        return Ok(new Test()
        {
            Name = data
        });
    }
}