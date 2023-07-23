namespace TemplateCQRS.Presentation.Extension
{
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Claims;
    using FluentValidation;
    using MediatR;
    using MediatR.Pipeline;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.IdentityModel.Tokens;
    using TemplateCQRS.Application.Features.Behaviors;
    using TemplateCQRS.Presentation.Middleware;
    using TemplateCQRS.Shared.Extensions;

    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();
            serviceCollection.AddHttpContextAccessor();
            serviceCollection.InstallServicesByAssembly(typeof(Infrastructure.AssemblyReference).Assembly, configuration);
            serviceCollection.InstallServicesByAssembly(typeof(Application.AssemblyReference).Assembly, configuration);
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            var applicationAssembly = typeof(Application.AssemblyReference).Assembly;
            serviceCollection.AddMediatR(applicationAssembly);
            serviceCollection.AddValidatorsFromAssembly(applicationAssembly);
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier,
                    };
                });


            return serviceCollection;
        }
    }
}

