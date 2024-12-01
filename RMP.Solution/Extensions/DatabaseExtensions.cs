using Microsoft.EntityFrameworkCore;
using RMP.Host.Database;

namespace RMP.Host.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddSQLDatabaseConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("SQLConnection")));

        return services;
    }

}
