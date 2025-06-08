namespace ams.service.repositories;

internal class RolePermissionRepository(AuthDbContext _context) : IRolePermissionRepository
{
    public async Task<List<Permission>> GetPermissionsForRoleAsync(int roleId)
    {
        return await _context.RolePermissions
            .Where(rp => rp.RoleId == roleId)
            .Include(rp => rp.Permission)
            .Select(rp => rp.Permission)
            .ToListAsync();
    }

    public async Task AddRolePermissionAsync(RolePermission rolePermission)
    {
        await _context.RolePermissions.AddAsync(rolePermission);
    }

    public void DeleteRolePermission(RolePermission rolePermission)
    {
        if (rolePermission != null)
        {
            _context.RolePermissions.Remove(rolePermission);
        }
    }
}

