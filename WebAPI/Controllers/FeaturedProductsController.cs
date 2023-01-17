using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class FeaturedProductsController : ControllerBase
{
    private readonly IFeaturedProductService _featuredProductService;

    public FeaturedProductsController(IFeaturedProductService featuredProductService)
    {
        _featuredProductService = featuredProductService;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var result = _featuredProductService.GetList();
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }
}