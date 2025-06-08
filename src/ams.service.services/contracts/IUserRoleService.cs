
namespace ams.service.services;

public interface IUserRoleService
{
    Task AssignRoleToUserAsync(int userId, int roleId);
    Task<List<RoleDto>> GetRolesForUserAsync(int userId);
}