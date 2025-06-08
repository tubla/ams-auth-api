namespace ams.service.services;

internal class PermissionService(IUnitOfWork _unitOfWork) : IPermissionService
{
    public async Task AddPermissionAsync(PermissionDto permission)
    {
        if (permission == null) throw new ArgumentNullException(nameof(permission));

        await _unitOfWork.PermissionRepository.AddPermissionAsync(permission.Adapt<Permission>());
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<PermissionDto>> GetAllPermissionsAsync()
    {
        var permissions = await _unitOfWork.PermissionRepository.GetAllPermissionsAsync();
        return permissions.Select(p => p.Adapt<PermissionDto>()).ToList();
    }
}

