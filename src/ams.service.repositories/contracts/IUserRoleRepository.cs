
namespace ams.service.repositories;

public interface IUserRoleRepository
{
    Task AddUserRoleAsync(UserRole userRole);
    void DeleteUserRole(UserRole userRole);
    Task<List<Role>> GetRolesForUserAsync(int userId);
}