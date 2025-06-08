namespace ams.web.api.Rbac;

public class PermissionRequirement(string _permission) : IAuthorizationRequirement
{
    public string Permission { get; } = _permission;
}


