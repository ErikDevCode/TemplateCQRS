namespace TemplateCQRS.Application.Installers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection.Metadata;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TemplateCQRS.Application.Features.Behaviors;
    using TemplateCQRS.Shared.Abstractions;

    [ExcludeFromCodeCoverage]
    public class MessagingInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var applicationAssembly = typeof(AssemblyReference).Assembly;
            services.AddMediatR(applicationAssembly);
            services.AddValidatorsFromAssembly(applicationAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}

