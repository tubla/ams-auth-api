namespace ams.service.services;

internal class RolePermissionService(IUnitOfWork _unitOfWork) : IRolePermissionService
{
    public async Task AssignPermissionToRoleAsync(int roleId, int permissionId)
    {
        var role = await _unitOfWork.RoleRepository.GetRoleByIdAsync(roleId)
            ?? throw new RecordNotFoundException($"Role with ID: {roleId} not found");

        var permission = await _unitOfWork.PermissionRepository.GetPermissionByNameAsync(permissionId.ToString())
            ?? throw new RecordNotFoundException($"Permission with ID: {permissionId} not found");

        var rolePermission = new RolePermission { RoleId = roleId, PermissionId = permissionId };
        await _unitOfWork.RolePermissionRepository.AddRolePermissionAsync(rolePermission);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<PermissionDto>> GetPermissionsForRoleAsync(int roleId)
    {
        var permissions = await _unitOfWork.RolePermissionRepository.GetPermissionsForRoleAsync(roleId);
        return permissions.Select(p => p.Adapt<PermissionDto>()).ToList();
    }
}

