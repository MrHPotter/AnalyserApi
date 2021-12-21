using System;

namespace AnalyserApi.Models.HelperModels;

public class DateRange
{
    public DateRange(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }
    public DateTime Start { get; }
    public DateTime End { get; }
}