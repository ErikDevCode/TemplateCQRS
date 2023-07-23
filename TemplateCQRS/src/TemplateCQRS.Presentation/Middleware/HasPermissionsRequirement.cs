namespace TemplateCQRS.Presentation.Middleware
{
    using Microsoft.AspNetCore.Authorization;

    public class HasPermissionsRequirement : IAuthorizationRequirement
    {
        public const string ClaimType = "permissions";

        public HasPermissionsRequirement(string permision, string issuer)
        {
            this.Permission = permision ?? throw new ArgumentNullException(nameof(permision));
            this.Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }

        public string Issuer { get; }

        public string Permission { get; }
    }
}

