namespace ams.web.api.Middlewares;

internal class RbacMiddleware(RequestDelegate _next, ILogger<RbacMiddleware> _logger)
{

    public async Task Invoke(HttpContext context, IUserService userService, IUserRoleService userRoleService, IRolePermissionService rolePermissionService)
    {
        try
        {
            var userEmail = context.User.FindFirst(ClaimTypes.Email)?.Value;
            _logger.LogInformation("RBAC Middleware invoked for user: {UserEmail}", userEmail);
            if (!string.IsNullOrEmpty(userEmail))
            {
                var user = await userService.GetUserByEmailAsync(userEmail);
                if (user != null)
                {
                    _logger.LogInformation("Retrieved user details for user: {UserEmail}", userEmail);
                    // Get user roles
                    var roles = await userRoleService.GetRolesForUserAsync(user.UserId);
                    _logger.LogInformation("Retrieved roles for user: {UserEmail}", userEmail);
                    // Get permissions for each role
                    var permissions = new HashSet<string>();
                    foreach (var role in roles)
                    {
                        var rolePermissions = await rolePermissionService.GetPermissionsForRoleAsync(role.RoleId);
                        foreach (var permission in rolePermissions)
                        {
                            permissions.Add(permission.PermissionName);
                        }
                    }

                    // Store roles & permissions in HttpContext for easy access in controllers
                    context.Items["UserRoles"] = roles.Select(r => r.RoleName).ToList();
                    context.Items["UserPermissions"] = permissions;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Type: {ExceptionType}, Message: {Message}",
                 ex.GetType().Name, ex.Message);
            throw new RecordNotFoundException(ex.Message);
        }
        finally
        {
            await _next(context);
        }
    }
}

