
namespace ams.service.repositories;

public interface IPermissionRepository
{
    Task AddPermissionAsync(Permission permission);
    void DeletePermission(Permission permission);
    Task<List<Permission>> GetAllPermissionsAsync();
    Task<Permission?> GetPermissionByNameAsync(string permissionName);
}