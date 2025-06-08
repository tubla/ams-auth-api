namespace ams.service.repositories;

public static class RepositoryLayerExtensions
{
    public static void ComposeRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
        services.AddScoped<ILoginHistoryRepository, LoginHistoryRepository>();

        services.AddDbContext<AuthDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("AmsDbConnection");
            options.UseSqlServer(connectionString,
            sqlOptions => sqlOptions.MigrationsAssembly(typeof(AuthDbContext).Assembly.GetName().Name));
        });
    }
}
