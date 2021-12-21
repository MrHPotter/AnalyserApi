using System;
using AnalyserApi.Models.Database;
using Microsoft.Extensions.Configuration;

namespace AnalyserApi.Appilication;

public class AnalyserConfig : IAnalyserConfig
{
    private IConfiguration _configuration;

    public AnalyserConfig(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public string ConnectionString => _configuration["Appsettings:ConnectionString"];

    public DbProvider DbProvider => Enum.Parse<DbProvider>(_configuration["Appsettings:DbType"], true);

    public bool UseLazyLoading => bool.Parse(_configuration["Appsettings:UseEfCoreLazyLoading"]);

    public bool LogEfCore => bool.Parse(_configuration["Appsettings:UseEfCoreLogging"]);
}