namespace ams.service.services;

internal class UserRoleService(IUnitOfWork _unitOfWork) : IUserRoleService
{
    public async Task AssignRoleToUserAsync(int userId, int roleId)
    {
        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            ?? throw new RecordNotFoundException($"User with ID: {userId} not found");

        var role = await _unitOfWork.RoleRepository.GetRoleByIdAsync(roleId)
            ?? throw new RecordNotFoundException($"Role with ID: {roleId} not found");

        var userRole = new UserRole { UserId = userId, RoleId = roleId };
        await _unitOfWork.UserRoleRepository.AddUserRoleAsync(userRole);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<RoleDto>> GetRolesForUserAsync(int userId)
    {
        var roles = await _unitOfWork.UserRoleRepository.GetRolesForUserAsync(userId);
        return roles.Select(r => r.Adapt<RoleDto>()).ToList();
    }
}

