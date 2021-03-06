using AnalyserApi.DataProviders;
using AnalyserApi.Extensions;
using AnalyserApi.Models.Enums;

namespace AnalyserApi.Managers;

public class ChoiceManager: IChoiceManager
{
    private readonly IDayOfWeekDataManager _dayOfWeekDataManager;
    private readonly IUnitOfWork _data;

    public ChoiceManager(IUnitOfWork data, IDayOfWeekDataManager dayOfWeekDataManager)
    {
        _data = data;
        _dayOfWeekDataManager = dayOfWeekDataManager;
    }

    public IEnumerable<CandleRange> GetAvailableCandleRanges()
    {
        return Enum.GetValues<CandleRange>();
    }

    public IEnumerable<string> GetAvailableSymbols()
    {
        return _data.PriceEntryRepository.GetAvailableSymbols();
    }

    public IEnumerable<string> GetAvailableMethods()
    {
        return _dayOfWeekDataManager.GetMethodNames();
    }
}