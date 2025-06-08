namespace ams.service.repositories;

internal class RoleRepository(AuthDbContext _context) : IRoleRepository
{
    public async Task<Role?> GetRoleByNameAsync(string roleName)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
    }

    public async Task<Role?> GetRoleByIdAsync(int roleId)
    {
        return await _context.Roles.FindAsync(roleId);
    }

    public async Task AddRoleAsync(Role role)
    {
        await _context.Roles.AddAsync(role);
    }

    public void DeleteRole(Role role)
    {
        if (role != null)
        {
            _context.Roles.Remove(role);
        }
    }
}

