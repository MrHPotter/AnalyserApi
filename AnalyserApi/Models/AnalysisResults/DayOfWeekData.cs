namespace AnalyserApi.Models.AnalysisResults;

public class DayOfWeekData
{
    protected DayOfWeekData(DayOfWeekData data)
    {
        Monday = data.Monday;
        Tuesday = data.Tuesday;
        Wednesday = data.Wednesday;
        Thursday = data.Thursday;
        Friday = data.Friday;
    }
    public DayOfWeekData()
    {
        Monday = null;
        Tuesday = null;
        Wednesday = null;
        Thursday = null;
        Friday = null;
    }

    private decimal? Monday { get; set; }
    private decimal? Tuesday { get; set; }
    private decimal? Wednesday { get; set; }
    private decimal? Thursday { get; set; }
    private decimal? Friday { get; set; }

    public DayOfWeekData AddDay(DayOfWeek day, decimal value)
    {
        switch (day)
        {
            case DayOfWeek.Monday:
                Monday = value;
                break;
            case DayOfWeek.Tuesday:
                Tuesday = value;
                break;
            case DayOfWeek.Wednesday:
                Wednesday = value;
                break;
            case DayOfWeek.Thursday:
                Thursday = value;
                break;
            case DayOfWeek.Friday:
                Friday = value;
                break;
            case DayOfWeek.Sunday:
            case DayOfWeek.Saturday:
            default:
                break;
        }

        return this;
    }
}