using Microsoft.AspNetCore.Mvc;
using TesteAuvo.Application.Interfaces.Services;

namespace TesteAuvo.Web.Mvc.Controllers;

public class TimeSheetClosureController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITimeSheetClosureService _timeSheetClosureService;
    private readonly IImportCsvDataService _importCsvDataService;
    public TimeSheetClosureController(ILogger<HomeController> logger, ITimeSheetClosureService timeSheetClosureService, IImportCsvDataService importCsvDataService)
    {
        _logger = logger;
        _timeSheetClosureService = timeSheetClosureService;
        _importCsvDataService = importCsvDataService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> AnalyzeData(string pathToDiretory)
    {
        //_timeSheetClosureService.GetTimeSheetClousure(pathToDiretory);
        await _importCsvDataService.ImportCsvDataFromDiretoryAsync(pathToDiretory);
        return View();
    }
}