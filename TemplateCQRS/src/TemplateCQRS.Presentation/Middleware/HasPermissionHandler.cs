namespace TemplateCQRS.Presentation.Middleware
{
    using Microsoft.AspNetCore.Authorization;

    public class HasPermissionHandler : AuthorizationHandler<HasPermissionsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionsRequirement requirement)
        {
            if (!context.User.HasClaim(x => x.Type == "permissions" && x.Issuer == requirement.Issuer))
            {
                return Task.CompletedTask;
            }

            // Split the scopes string into an array
            var permissions = context.User.FindAll(c => c.Type == HasPermissionsRequirement.ClaimType
                                                        && c.Issuer == requirement.Issuer).Select(p => p.Value);

            // Succeed if the scope array contains the required scope
            if (permissions.Any(s => s == requirement.Permission))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

