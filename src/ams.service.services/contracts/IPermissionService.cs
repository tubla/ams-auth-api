
namespace ams.service.services;

public interface IPermissionService
{
    Task AddPermissionAsync(PermissionDto permission);
    Task<List<PermissionDto>> GetAllPermissionsAsync();
}