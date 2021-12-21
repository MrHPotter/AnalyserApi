﻿using System;
using System.Collections.Generic;
using System.Linq;
using AnalyserApi.Models.AnalysisResults;
using FluentAssertions;

namespace AnalyserApi.Extensions;

public static class ManagerExtensions
{
    private const string CallerMethodName = "CallMethodByName";
    public static string[] GetDayOfWeekMethods<T>(this T manager)
    {
        return manager is null ? Array.Empty<string>() :
            manager.GetType().Methods().ThatReturn<DayOfWeekData>().Where(m => m.Name != CallerMethodName)
                .Select(i => i.Name).ToArray();
    }
}