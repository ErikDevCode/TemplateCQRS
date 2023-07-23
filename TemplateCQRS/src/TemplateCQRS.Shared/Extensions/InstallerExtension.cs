namespace TemplateCQRS.Shared.Extensions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TemplateCQRS.Shared.Abstractions;

    [ExcludeFromCodeCoverage]
    public static class InstallerExtension
    {
        public static void InstallServicesByAssembly(this IServiceCollection services, Assembly assembly, IConfiguration configuration)
        {
            var installers = assembly.ExportedTypes.Where(x =>
                    typeof(IInstaller).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false })
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}

