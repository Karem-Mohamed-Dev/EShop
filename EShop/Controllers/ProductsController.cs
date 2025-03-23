using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EShop.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _productService.GetAllAsync(cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _productService.GetAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost]
    [HasPermission(Permissions.AddProduct)]
    public async Task<IActionResult> Add([FromBody] ProductRequest request, CancellationToken cancellationToken)
    {
        Guid userId = User.GetId();
        var result = await _productService.AddAsync(userId, request, cancellationToken);
        return result.IsSuccess ? CreatedAtAction(nameof(Get), new { result.Value.Id }, result.Value) : result.ToProblem();
    }

    [HttpPut("{id}")]
    [HasPermission(Permissions.UpdateProduct)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ProductRequest request, CancellationToken cancellationToken)
    {
        Guid userId = User.GetId();
        var result = await _productService.UpdateAsync(id, userId, request, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPut("{id}/toggle-status")]
    [HasPermission(Permissions.ToggleProductStatus)]
    public async Task<IActionResult> ToggleStatus([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        Guid userId = User.GetId();
        var result = await _productService.ToggleStatusAsync(id, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}