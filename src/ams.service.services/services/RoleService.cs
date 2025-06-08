namespace ams.service.services;

internal class RoleService(IUnitOfWork _unitOfWork) : IRoleService
{
    public async Task AddRoleAsync(RoleDto role)
    {
        if (role == null) throw new ArgumentNullException(nameof(role));

        await _unitOfWork.RoleRepository.AddRoleAsync(role.Adapt<Role>());
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteRoleAsync(int roleId)
    {
        var role = await _unitOfWork.RoleRepository.GetRoleByIdAsync(roleId)
            ?? throw new RecordNotFoundException($"Role with ID: {roleId} not found");

        _unitOfWork.RoleRepository.DeleteRole(role);
        await _unitOfWork.SaveAsync();
    }

    public async Task<RoleDto?> GetRoleByNameAsync(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName)) throw new ArgumentException("Role name cannot be empty", nameof(roleName));

        var role = await _unitOfWork.RoleRepository.GetRoleByNameAsync(roleName)
            ?? throw new RecordNotFoundException($"Role '{roleName}' does not exist");

        return role.Adapt<RoleDto>();
    }
}

