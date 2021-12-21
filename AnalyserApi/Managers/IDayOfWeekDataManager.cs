using AnalyserApi.Models.AnalysisResults;
using AnalyserApi.Models.HelperModels;
using TradingCsvAnalyser.Models.Enums;

namespace AnalyserApi.Managers;

public interface IDayOfWeekDataManager
{
    public DayOfWeekData GetAverageRangePerDay(DoWDefaultParameters parameters);

    public DayOfWeekData GetSumRangePerDay(DoWDefaultParameters parameters);
    public DayOfWeekData GetUpDayRatioPerDay(string symbol);
    public DayOfWeekData CallMethodByName(string method, DoWDefaultParameters doWDefaultParameters);
}