using AnalyserApi.DataProviders;
using AnalyserApi.Managers;
using AnalyserApi.Appilication;
using AnalyserApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace AnalyserApi.Extensions;

public static class ServiceCollectionExtensions
{

    /// <summary>
    /// a basic console logger factory
    /// </summary>
    private static ILoggerFactory ConsoleLoggerFactory { get; set; } = new LoggerFactory();

    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var config = new AnalyserConfig(configuration);
        services.AddDbContext<AnalyserContext>(config);
        services.AddSingleton<IAnalyserConfig, AnalyserConfig>(_ => config);
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IDayOfWeekDataManager, DayOfWeekDataManager>();
    }

    private static void AddDbContext<TContext>(this IServiceCollection services, IAnalyserConfig config)
    where TContext : DbContext
    {
        Action<DbContextOptionsBuilder> useDb = config.DbProvider switch
        {
            DbProvider.SqLite => builder => builder.UseSqlite(config.ConnectionString),
            DbProvider.PostgreSql => builder => builder.UseNpgsql(config.ConnectionString),
            DbProvider.MySql => builder => builder.UseMySql
                (config.ConnectionString, ServerVersion.AutoDetect(config.ConnectionString)),
            _ => throw new ArgumentOutOfRangeException(nameof(config.DbProvider),
                $"This {nameof(DbProvider)} is not supported")
        };

        services.AddDbContext<TContext>(options =>
        {
            useDb(options);
            if (config.UseLazyLoading) options = options.UseLazyLoadingProxies();
            if (config.LogEfCore) options.UseLoggerFactory(ConsoleLoggerFactory);

        }, ServiceLifetime.Singleton);
    }

}