namespace TemplateCQRS.Infrastructure.Installers
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TemplateCQRS.Shared.Abstractions;
    using TemplateCQRS.Shared.Providers;

    [ExcludeFromCodeCoverage]
    public class ProviderInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        }
    }
}

