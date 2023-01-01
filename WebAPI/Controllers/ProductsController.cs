using Business.Abstract;
using Core.DataAccess.Dynamic;
using Entities.Dtos.Products;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public IActionResult Add(AddProductDto addProductDto)
    {
        var result = _productService.Add(addProductDto);
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _productService.Delete(id);
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _productService.GetById(id);
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var result = _productService.GetList();
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpPost("[action]")]
    public IActionResult GetListByDynamic(Dynamic? dynamic = null)
    {
        var result = _productService.GetListByDynamic(dynamic);
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }

    [HttpPut]
    public IActionResult Update(UpdateProductDto updateProductDto)
    {
        var result = _productService.Update(updateProductDto);
        if (result.Success)
            return Ok(result);

        return BadRequest(result);
    }
}