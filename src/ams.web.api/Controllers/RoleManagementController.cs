namespace ams.web.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleManagementController(
    IRoleService _roleService,
    IUserRoleService _userRoleService,
    IPermissionService _permissionService,
    IRolePermissionService _rolePermissionService) : ControllerBase
{

    [Authorize(Roles = "Admin")]
    [HttpPost("roles")]
    public async Task<IActionResult> CreateRole([FromBody] RoleDto role)
    {
        await _roleService.AddRoleAsync(role);
        return Ok(new { message = "Role created successfully" });
    }

    [Authorize]
    [HttpGet("roles/{roleName}")]
    public async Task<IActionResult> GetRoleByName(string roleName)
    {
        var role = await _roleService.GetRoleByNameAsync(roleName);
        return Ok(role);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("roles/{roleId}")]
    public async Task<IActionResult> DeleteRole(int roleId)
    {
        await _roleService.DeleteRoleAsync(roleId);
        return Ok(new { message = "Role deleted successfully" });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRoleToUser([FromBody] AssignUserRoleDto request)
    {
        await _userRoleService.AssignRoleToUserAsync(request.UserId, request.RoleId);
        return Ok(new { message = "Role assigned successfully" });
    }

    [Authorize]
    [HttpGet("user/{userId}/roles")]
    public async Task<IActionResult> GetRolesForUser(int userId)
    {
        var roles = await _userRoleService.GetRolesForUserAsync(userId);
        return Ok(roles);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("permissions")]
    public async Task<IActionResult> CreatePermission([FromBody] PermissionDto permission)
    {
        await _permissionService.AddPermissionAsync(permission);
        return Ok(new { message = "Permission created successfully" });
    }

    [Authorize]
    [HttpGet("permissions")]
    public async Task<IActionResult> GetAllPermissions()
    {
        var permissions = await _permissionService.GetAllPermissionsAsync();
        return Ok(permissions);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("assign-permission")]
    public async Task<IActionResult> AssignPermissionToRole([FromBody] AssignRolePermissionDto request)
    {
        await _rolePermissionService.AssignPermissionToRoleAsync(request.RoleId, request.PermissionId);
        return Ok(new { message = "Permission assigned to role successfully" });
    }

    [Authorize]
    [HttpGet("roles/{roleId}/permissions")]
    public async Task<IActionResult> GetPermissionsForRole(int roleId)
    {
        var permissions = await _rolePermissionService.GetPermissionsForRoleAsync(roleId);
        return Ok(permissions);
    }
}
