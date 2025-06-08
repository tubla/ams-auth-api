namespace ams.service.repositories;

internal class PermissionRepository(AuthDbContext _context) : IPermissionRepository
{
    public async Task<Permission?> GetPermissionByNameAsync(string permissionName)
    {
        return await _context.Permissions.FirstOrDefaultAsync(p => p.PermissionName == permissionName);
    }

    public async Task<List<Permission>> GetAllPermissionsAsync()
    {
        return await _context.Permissions.ToListAsync();
    }

    public async Task AddPermissionAsync(Permission permission)
    {
        await _context.Permissions.AddAsync(permission);
    }

    public void DeletePermission(Permission permission)
    {
        if (permission != null)
        {
            _context.Permissions.Remove(permission);
        }
    }
}

