namespace ams.service.repositories;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IUserRoleRepository UserRoleRepository { get; }
    IRoleRepository RoleRepository { get; }
    IRolePermissionRepository RolePermissionRepository { get; }
    IPermissionRepository PermissionRepository { get; }
    ILoginHistoryRepository LoginHistoryRepository { get; }
    Task<int> SaveAsync();
}

public class UnitOfWork(AuthDbContext _context) : IUnitOfWork
{
    private IUserRepository? _userRepository;
    private IUserRoleRepository? _userRoleRepository;
    private IRoleRepository? _roleRepository;
    private IRolePermissionRepository? _rolePermissionRepository;
    private IPermissionRepository? _permissionRepository;
    private ILoginHistoryRepository? _loginHistoryRepository;
    public IUserRepository UserRepository
    {
        get
        {
            _userRepository = _userRepository ?? new UserRepository(_context);
            return _userRepository;
        }
    }

    public IUserRoleRepository UserRoleRepository
    {
        get
        {
            _userRoleRepository = _userRoleRepository ?? new UserRoleRepository(_context);
            return _userRoleRepository;
        }
    }

    public IRoleRepository RoleRepository
    {
        get
        {
            _roleRepository = _roleRepository ?? new RoleRepository(_context);
            return _roleRepository;
        }
    }

    public IRolePermissionRepository RolePermissionRepository
    {
        get
        {
            _rolePermissionRepository = _rolePermissionRepository ?? new RolePermissionRepository(_context);
            return _rolePermissionRepository;
        }
    }

    public IPermissionRepository PermissionRepository
    {
        get
        {
            _permissionRepository = _permissionRepository ?? new PermissionRepository(_context);
            return _permissionRepository;
        }
    }

    public ILoginHistoryRepository LoginHistoryRepository
    {
        get
        {
            _loginHistoryRepository = _loginHistoryRepository ?? new LoginHistoryRepository(_context);
            return _loginHistoryRepository;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
