using Microsoft.AspNetCore.Mvc;

namespace EShop.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RolesController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;

    [HttpGet("")]
    [HasPermission(Permissions.GetRoles)]
    public async Task<IActionResult> GetAll([FromQuery] bool includeDisabled, CancellationToken cancellationToken)
    {
        var result = await _roleService.GetAllAsync(includeDisabled, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [HasPermission(Permissions.GetRoles)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _roleService.GetAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost]
    [HasPermission(Permissions.AddRoles)]
    public async Task<IActionResult> Add([FromBody] RoleRequest request, CancellationToken cancellationToken)
    {
        var result = await _roleService.AddAsync(request, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPut("{id}")]
    [HasPermission(Permissions.UpdateRoles)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RoleRequest request, CancellationToken cancellationToken)
    {
        var result = await _roleService.UpdateAsync(id, request, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPut("{id}/toggle-status")]
    [HasPermission(Permissions.ToggleRoleStatus)]
    public async Task<IActionResult> ToggleDisable([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var result = await _roleService.ToggleDisableAsync(id, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPost("assign-user-role")]
    [HasPermission(Permissions.AssignUserRole)]
    public async Task<IActionResult> AssignUserRole([FromBody] UserRoleRequest request, CancellationToken cancellationToken)
    {
        var result = await _roleService.AssignUserRoleAsync(request, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPost("remove-user-role")]
    [HasPermission(Permissions.RemoveUserRole)]
    public async Task<IActionResult> RemoveUserRole([FromBody] UserRoleRequest request, CancellationToken cancellationToken)
    {
        var result = await _roleService.RemoveUserRoleAsync(request, cancellationToken);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}
