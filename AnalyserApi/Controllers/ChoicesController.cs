using AnalyserApi.Managers;
using AnalyserApi.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace AnalyserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ChoicesController
{
    private readonly IChoiceManager _choiceManager;

    public ChoicesController(IChoiceManager choiceManager)
    {
        _choiceManager = choiceManager;
    }

    [HttpGet("Methods")]
    public ActionResult<string[]> GetAvailableMethods()
    {
        return _choiceManager.GetAvailableMethods().ToArray();
    }

    [HttpGet("Symbols")]
    public ActionResult<string[]> GetAvailableSymbols()
    {
        return _choiceManager.GetAvailableSymbols().ToArray();
    }

    [HttpGet("CandleRanges")]
    public ActionResult<CandleRange[]> GetAvailableRanges()
    {
        return _choiceManager.GetAvailableCandleRanges().ToArray();
    }
}