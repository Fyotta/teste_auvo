using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
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
        await _importCsvDataService.ImportCsvDataFromDiretoryAsync(pathToDiretory);
        var result = await _timeSheetClosureService.GetTimeSheetClosureJson();
        var jsonOpts = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(result, jsonOpts);
        ViewBag.jsonContent = json;
        return View();
    }
}