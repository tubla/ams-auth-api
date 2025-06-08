namespace ams.service.services;

public static class ServiceLayerExtensions
{
    public static void ComposeRepositories(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IRolePermissionService, RolePermissionService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<ILoginHistoryService, LoginHistoryService>();
    }
}
