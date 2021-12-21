using AnalyserApi.Models.Enums;

namespace AnalyserApi.Managers;

public interface IChoiceManager
{
    public IEnumerable<CandleRange> GetAvailableCandleRanges();

    public IEnumerable<string> GetAvailableSymbols();

    public IEnumerable<string> GetAvailableMethods();

}