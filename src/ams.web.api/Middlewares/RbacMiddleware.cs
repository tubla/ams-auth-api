namespace ams.web.api.Middlewares;

internal class RbacMiddleware(RequestDelegate _next)
{

    public async Task Invoke(HttpContext context, IUserService userService, IUserRoleService userRoleService, IRolePermissionService rolePermissionService)
    {
        var userEmail = context.User.FindFirst(ClaimTypes.Email)?.Value;

        if (!string.IsNullOrEmpty(userEmail))
        {
            var user = await userService.GetUserByEmailAsync(userEmail);
            if (user != null)
            {
                // Get user roles
                var roles = await userRoleService.GetRolesForUserAsync(user.UserId);

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

        await _next(context);
    }
}

