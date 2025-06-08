
namespace ams.service.services;

public interface IRoleService
{
    Task AddRoleAsync(RoleDto role);
    Task DeleteRoleAsync(int roleId);
    Task<RoleDto?> GetRoleByNameAsync(string roleName);
}