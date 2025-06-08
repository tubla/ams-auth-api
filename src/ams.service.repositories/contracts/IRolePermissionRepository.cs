
namespace ams.service.repositories;

public interface IRolePermissionRepository
{
    Task AddRolePermissionAsync(RolePermission rolePermission);
    void DeleteRolePermission(RolePermission rolePermission);
    Task<List<Permission>> GetPermissionsForRoleAsync(int roleId);
}