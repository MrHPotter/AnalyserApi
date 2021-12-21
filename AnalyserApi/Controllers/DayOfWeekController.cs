using System.ComponentModel.DataAnnotations;
using AnalyserApi.Extensions;
using AnalyserApi.Managers;
using AnalyserApi.Models.AnalysisResults;
using AnalyserApi.Models.Enums;
using AnalyserApi.Models.HelperModels;
using Microsoft.AspNetCore.Mvc;

namespace AnalyserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DayOfWeekController : ControllerBase
{
    private readonly IDayOfWeekDataManager _dataManager;

    public DayOfWeekController(IDayOfWeekDataManager dataManager)
    {
        _dataManager = dataManager;
    }

    [HttpGet("{method}")]
    public ActionResult<DayOfWeekData> Analyse(string method, [FromQuery] DoWDefaultParameters parameters)
    {
        return _dataManager.CallMethodByName(method, parameters);
    }

}