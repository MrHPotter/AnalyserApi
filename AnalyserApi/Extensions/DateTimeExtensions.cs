using AnalyserApi.Models.HelperModels;

namespace AnalyserApi.Extensions;

public static class DateTimeExtensions
{
    public static int GetWeekOfYear(this DateTime date)
    {
        var afterFirst = date.FirstOfYear().AddDays(7 - (int)date.DayOfWeek);
        return 1 + (date.DayOfYear - afterFirst.DayOfYear) / 7;
    }

    private static DateTime FirstOfYear(this DateTime date)
    {
        return new DateTime(date.Year, 1, 1);
    }

    private static DateTime MostRecentSunday(this DateTime date)
    {
        return date.AddDays(-(int)date.DayOfWeek);
    }

    public static DateRange MarketWeek(this DateTime date)
    {
        var monday = date.MostRecentSunday().AddDays(1).Date;
        return new DateRange(monday, monday.AddDays(5));
    }

    public static DateOnly DateOnly(this DateTime date)
    {
        return new DateOnly(date.Year, date.Month, date.Day);
    }
    public static DateOnly DateOnly(this DateTimeOffset date)
    {
        return new DateOnly(date.Year, date.Month, date.Day);
    }
}