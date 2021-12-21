using System;
using AnalyserApi.DataProviders;
using AnalyserApi.Managers;
using AnalyserApi.Appilication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AnalyserApi.Extensions;

public static class ServiceCollectionExtensions
{

    /// <summary>
    /// a basic console logger factory
    /// </summary>
    public static ILoggerFactory ConsoleLoggerFactory { get; set; } = new LoggerFactory();

    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IAnalyserConfig, AnalyserConfig>();
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IDayOfWeekDataManager, DayOfWeekDataManager>();
    }

}