namespace ams.web.api.Rbac;

public class PermissionHandler(IHttpContextAccessor _httpContextAccessor) : AuthorizationHandler<PermissionRequirement>
{

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        // Get user permissions stored in HttpContext from RBAC Middleware
        var userPermissions = _httpContextAccessor.HttpContext!.Items["UserPermissions"] as HashSet<string>;

        if (userPermissions != null && userPermissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}

