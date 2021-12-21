using AnalyserApi.Helpers;
using FluentAssertions;

namespace AnalyserApi.Extensions;

public static class ManagerExtensions
{
    
    public static string[] GetMethodNames<T>(this T manager)
    {
        return manager is null ? Array.Empty<string>() :
            manager.GetType().Methods().Where(m => m.Name != GlobalConstants.CallerMethodName)
                .Select(i => i.Name).ToArray();
    }
}