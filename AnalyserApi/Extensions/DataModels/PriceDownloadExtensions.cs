using AnalyserApi.Models;
using AnalyserApi.Models.SourceModels;
using System.Collections.Generic;
using System.Linq;

namespace AnalyserApi.Extensions.DataModels;

public static class PriceDownloadExtensions
{
    public static IEnumerable<PriceDownloadWithSymbol> AddSymbol(this IEnumerable<PriceDownload> downloads,
        string symbol)
    {
        return downloads.Select(download => new PriceDownloadWithSymbol(download, symbol));
    }

    public static IEnumerable<PriceEntry> ToPriceEntries(this IEnumerable<PriceDownload> downloads,
        string symbol)
    {
        return downloads.Select(download => new PriceEntry(download, symbol));
    }
}