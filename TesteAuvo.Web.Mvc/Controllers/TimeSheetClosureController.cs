using Microsoft.AspNetCore.Mvc;
using TesteAuvo.Application.Interfaces.Services;

namespace TesteAuvo.Web.Mvc.Controllers;

public class TimeSheetClosureController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITimeSheetClosureService _timeSheetClosureService;
    public TimeSheetClosureController(ILogger<HomeController> logger, ITimeSheetClosureService timeSheetClosureService)
    {
        _logger = logger;
        _timeSheetClosureService = timeSheetClosureService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AnalyzeData(string pathToDiretory)
    {
        _timeSheetClosureService.GetTimeSheetClousure(pathToDiretory);
        return View();
    }
}