using AnalyserApi.DataProviders;
using AnalyserApi.Extensions.DataModels;
using AnalyserApi.Models.AnalysisResults;
using AnalyserApi.Models.HelperModels;
using System;

namespace AnalyserApi.Managers;

public class DayOfWeekDataManager : IDayOfWeekDataManager
{
    private readonly IUnitOfWork _data;

    public DayOfWeekDataManager(IUnitOfWork data)
    {
        _data = data;
    }

    public DayOfWeekData GetAverageRangePerDay(DoWDefaultParameters parameters)
    {
        return _data.PriceEntryRepository.GetEntriesForSymbol(parameters.Symbol).FilterByDayResult(parameters.DayFilter)
            .GetAveragePerDay(i => i.Range(parameters.RangeType));
    }

    public DayOfWeekData GetSumRangePerDay(DoWDefaultParameters parameters)
    {
        return _data.PriceEntryRepository.GetEntriesForSymbol(parameters.Symbol).FilterByDayResult(parameters.DayFilter)
            .GetSumPerDay(i => i.Range(parameters.RangeType));
    }

    public DayOfWeekData GetUpDayRatioPerDay(string symbol)
    {
        return _data.PriceEntryRepository.GetEntriesForSymbol(symbol)
            .GetUpDayRatioPerDay();
    }

    public DayOfWeekData CallMethodByName(string method, DoWDefaultParameters parameters)
    {
        return method switch
        {
            nameof(GetAverageRangePerDay) => GetAverageRangePerDay(parameters),
            nameof(GetSumRangePerDay) => GetSumRangePerDay(parameters),
            nameof(GetUpDayRatioPerDay) => GetUpDayRatioPerDay(parameters.Symbol),
            _ => throw new ArgumentException($"{method} is not a valid Method")
        };
    }
}