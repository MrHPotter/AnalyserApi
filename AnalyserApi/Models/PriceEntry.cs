using System;
using System.Collections.Generic;
using AnalyserApi.Extensions;
using AnalyserApi.Models.Enums;
using AnalyserApi.Models.SourceModels;
using Microsoft.Win32;


namespace AnalyserApi.Models;

public class PriceEntry
{
    public PriceEntry()
    {
        
    }
    public PriceEntry(DateTimeOffset dateAndTime, decimal open, decimal high,
        decimal low, decimal close, string symbol)
    {
        DateAndTime = dateAndTime.LocalDateTime;
        Open = open;
        High = high;
        Low = low;
        Close = close;
        Symbol = symbol;
    }

    public PriceEntry(PriceDownload input, string symbol)
    {
        DateAndTime = input.Date.LocalDateTime;
        Close = input.Price;
        Open = input.Open;
        High = input.High;
        Low = input.Low;
        Symbol = symbol;
    }

    public DateTime DateAndTime { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    public DayOfWeek Day => DateAndTime.DayOfWeek;
    public DateOnly Date => DateAndTime.DateOnly();
    public string Symbol { get; set; }

    public override int GetHashCode()
    {
        var hashBase = (Open + High - Close - Low)*(int)Day;
        return hashBase.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as PriceEntry);
    }

    private bool Equals(PriceEntry? entry)
    {
        if (entry is null)
            return false;

        if (ReferenceEquals(this, entry)) return true;

        return entry.Close == Close &&
               entry.Date == Date &&
               entry.Day == Day &&
               entry.High == High &&
               entry.Low == Low &&
               entry.Open == Open &&
               entry.Symbol == Symbol &&
               entry.DateAndTime == DateAndTime;
    }

    public decimal Range(CandleRange rangeType) => rangeType switch
    {
        CandleRange.HighClose => HighCloseRange(),
        CandleRange.HighLow => HighLowRange(),
        CandleRange.LowClose => LowCloseRange(),
        CandleRange.OpenClose => OpenCloseRange(),
        CandleRange.OpenHigh => OpenHighRange(),
        CandleRange.OpenLow => OpenLowRange(),
        _ => throw new ArgumentOutOfRangeException(nameof(rangeType), $"Unexpected value for Range Type: {rangeType}")
    };

    private decimal OpenCloseRange() => Close - Open;
    private decimal HighLowRange() => High - Low;
    private decimal OpenHighRange() => High - Open;
    private decimal OpenLowRange() => Open - Low;
    private decimal LowCloseRange() => Close - Low;
    private decimal HighCloseRange() => High - Close;

    public static implicit operator PriceEntry?(PriceDownloadWithSymbol? download)
    {
        if (download is null) return null;
        return new(download, download.Symbol);
    }
}