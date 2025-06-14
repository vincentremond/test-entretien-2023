using CiteoInterview.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CiteoInterview.Api.Controllers;

[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ShopDbContext _shopDbContext;

    public ProductsController(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    [HttpGet]
    public async Task<ActionResult> GetProducts() => Ok(await _shopDbContext.Product.ToListAsync());

    [HttpGet("{productId}")]
    public async Task<ActionResult> GetProduct([FromRoute] int productId)
    {
        var findAsync = await _shopDbContext.Product.FindAsync(productId);
        if (findAsync == null)
        {
            return NotFound();
        }

        return Ok(findAsync);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Product product)
    {
        await _shopDbContext.AddAsync(product);
        await _shopDbContext.SaveChangesAsync();
        return Ok();
    }
}
