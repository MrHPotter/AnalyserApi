using AnalyserApi.Models.Enums;

namespace AnalyserApi.Models.HelperModels;

public class DoWDefaultParameters
{
    public DoWDefaultParameters(){}
    public DoWDefaultParameters(CandleRange rangeType, string symbol, DayFilter dayFilter)
    {
        RangeType = rangeType;
        Symbol = symbol;
        DayFilter = dayFilter;
    }

    public CandleRange RangeType { get; set; }
    public string Symbol { get; set; }
    public DayFilter DayFilter { get; set; }
}