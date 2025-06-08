namespace ams.service.repositories;

internal class UserRoleRepository(AuthDbContext _context) : IUserRoleRepository
{
    public async Task<List<Role>> GetRolesForUserAsync(int userId)
    {
        return await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Include(ur => ur.Role)
            .Select(ur => ur.Role)
            .ToListAsync();
    }

    public async Task AddUserRoleAsync(UserRole userRole)
    {
        await _context.UserRoles.AddAsync(userRole);
    }

    public void DeleteUserRole(UserRole userRole)
    {
        if (userRole != null)
        {
            _context.UserRoles.Remove(userRole);
        }
    }
}
