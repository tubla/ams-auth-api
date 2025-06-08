
namespace ams.service.repositories;

public interface IRoleRepository
{
    Task AddRoleAsync(Role role);
    void DeleteRole(Role role);
    Task<Role?> GetRoleByIdAsync(int roleId);
    Task<Role?> GetRoleByNameAsync(string roleName);
}