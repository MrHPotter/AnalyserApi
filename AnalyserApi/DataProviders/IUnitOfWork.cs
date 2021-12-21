using AnalyserApi.DataProviders.Repositories;

namespace AnalyserApi.DataProviders;

public interface IUnitOfWork
{
    public IPriceEntryRepository PriceEntryRepository { get; }
    public void SaveChanges();
}