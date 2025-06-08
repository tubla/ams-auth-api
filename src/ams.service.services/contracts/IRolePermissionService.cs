
namespace ams.service.services;

public interface IRolePermissionService
{
    Task AssignPermissionToRoleAsync(int roleId, int permissionId);
    Task<List<PermissionDto>> GetPermissionsForRoleAsync(int roleId);
}