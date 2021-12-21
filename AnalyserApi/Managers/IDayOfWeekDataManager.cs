using AnalyserApi.Models.AnalysisResults;
using AnalyserApi.Models.HelperModels;


namespace AnalyserApi.Managers;

public interface IDayOfWeekDataManager
{
    public DayOfWeekData GetAverageRangePerDay(DoWDefaultParameters parameters);

    public DayOfWeekData GetSumRangePerDay(DoWDefaultParameters parameters);
    public DayOfWeekData GetUpDayRatioPerDay(string symbol);
    public DayOfWeekData CallMethodByName(string method, DoWDefaultParameters doWDefaultParameters);
}