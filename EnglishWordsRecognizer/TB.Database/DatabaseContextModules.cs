using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TB.Database.GenericRepositories;

namespace TB.Database;

public static class DatabaseContextModules
{
    public static void ApplyDataBaseDI(this IServiceCollection services, string dbConnection)
    {
        services.AddDbContext<TB_DatabaseContext>
        (
            options => options.UseNpgsql(dbConnection), 
            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Transient
        );

        services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
    }
}