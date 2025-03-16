using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SubCategoriesController(ISubCategoryService subCategoryService) : ControllerBase
{
    private readonly ISubCategoryService _subCategoryService = subCategoryService;

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetAll([FromRoute] Guid categoryId, [FromQuery] bool includeDisabled, CancellationToken cancellationToken)
    {
        var result = await _subCategoryService.GetAllAsync(categoryId, includeDisabled, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _subCategoryService.GetAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("")]
    [HasPermission(Permissions.AddSubCategory)]
    public async Task<IActionResult> Add([FromBody] SubCategoryRequest request, CancellationToken cancellationToken)
    {
        var result = await _subCategoryService.AddAsync(request, cancellationToken);
        return result.IsSuccess ? CreatedAtAction(nameof(Get), new { result.Value.Id }, result.Value) : result.ToProblem();
    }

    [HttpPut("{id}")]
    [HasPermission(Permissions.UpdateSubCategory)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SubCategoryRequest request, CancellationToken cancellationToken)
    {
        var result = await _subCategoryService.UpdateAsync(id, request, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPut("{id}/toggle-status")]
    [HasPermission(Permissions.ToggleSubCategoryStatus)]
    public async Task<IActionResult> ToggleStatus([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _subCategoryService.ToggleStatusAsync(id, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
