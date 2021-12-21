using AnalyserApi.Models.Enums;

namespace AnalyserApi.Models.AnalysisResults;

public class DoWOverview : DayOfWeekData
{
    public DoWOverview(string symbol, CandleRange range, string method)
    {
        Symbol = symbol;
        Method = method;
        Range = range;
    }

    public DoWOverview(DayOfWeekData data, string symbol, CandleRange range, string method, DayFilter dayFilter) : base(data)
    {
        Symbol = symbol;
        Method = method;
        DayFilter = dayFilter;
        Range = range;
    }
    public string Symbol { get; set; }

    public string Method { get; set; }

    public CandleRange Range { get; set; }

    public DayFilter DayFilter { get; set; }
}