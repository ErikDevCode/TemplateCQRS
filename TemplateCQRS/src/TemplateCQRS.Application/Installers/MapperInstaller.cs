

namespace TemplateCQRS.Application.Installers
{
    using System.Diagnostics.CodeAnalysis;
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TemplateCQRS.Shared.Abstractions;

    [ExcludeFromCodeCoverage]
    public class MapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(Application.AssemblyReference));
            }).CreateMapper());
        }
    }
}

