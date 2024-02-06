using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructer
{
    public static class DependencyContexts
    {
        public static IServiceCollection AddInfrastructures(this IServiceCollection services, IConfiguration config)
        {

            return services;

        }
        public static void SetSqlServerOptions(this DbContextOptionsBuilder builder, IConfiguration conf)
        {
            var connectionString = Environment.GetEnvironmentVariable("DBHOST");
            // string connectionString = conf[$"ConnectionStrings:Default"];
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("espserver"));
        }


    }
}
