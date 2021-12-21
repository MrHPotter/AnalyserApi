using AnalyserApi.Models.Database;
using System.Data;

namespace AnalyserApi.Appilication;

public interface IAnalyserConfig
{
    public string ConnectionString { get; }

    public DbProvider DbProvider { get; }

    public bool UseLazyLoading { get; }

    public bool LogEfCore { get; }
}