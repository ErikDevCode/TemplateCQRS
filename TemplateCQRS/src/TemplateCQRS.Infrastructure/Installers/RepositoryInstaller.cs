namespace TemplateCQRS.Infrastructure.Installers
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TemplateCQRS.Domain.Repository;
    using TemplateCQRS.Infrastructure.Repository;
    using TemplateCQRS.Shared.Abstractions;

    [ExcludeFromCodeCoverage]
    public class RepositoryInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var supportDbConnectionString = configuration.GetConnectionString("SupportDataBase");
            if (string.IsNullOrEmpty(supportDbConnectionString))
            {
                throw new InvalidOperationException("Falta configurar la cadena de conexión de la BD");
            }

            services.AddScoped(_ => new SqlConnection(supportDbConnectionString));
            services.AddScoped<IDbTransaction>(s =>
            {
                var conn = s.GetRequiredService<SqlConnection>();
                conn.Open();
                return conn.BeginTransaction();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISaleOrderRepository, SaleOrderRepository>();
        }
    }
}

