namespace ams.web.api.Extensions;

public static class ServiceExtensions
{
    public static void ComposeAll(this IServiceCollection services, IConfiguration configuration)
    {
        RepositoryLayerExtensions.ComposeRepositories(services, configuration);
        ServiceLayerExtensions.ComposeApplicationServices(services);
    }
}
