using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TB.Database.GenericRepositories;
using TB.Database.Repositories;

namespace TB.Database;

public static class DatabaseContextModules
{
    public static void ApplyDataBaseDI(this IServiceCollection services, string dbConnection)
    {
        services.AddDbContext<TBDatabaseContext>
        (
            options => options.UseNpgsql(dbConnection), 
            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Transient
        );

        services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));

        services.AddSingleton<TranslateCacheRepository>();
        services.AddSingleton<PlanCacheRepository>();

        services.AddTransient<UserSettingsRepository>();

        services.AddTransient<TelegramUserRepository>();
        services.AddTransient<UserPlansRepository>();

        services.AddTransient<AudioRequestRepository>();
        services.AddTransient<TextRequestRepository>();
        services.AddTransient<ImageRequestRepository>();
    }
}