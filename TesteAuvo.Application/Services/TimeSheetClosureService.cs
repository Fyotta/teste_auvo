using TesteAuvo.Application.Dtos;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Mapping;
using TesteAuvo.Application.ViewModels;

namespace TesteAuvo.Application.Services;

public class TimeSheetClosureService : ITimeSheetClosureService
{

    private readonly ICsvParserService<TimeRecordCSVInputMap, TimeRecordCSVInputDTO> _csvParserService;
    public TimeSheetClosureService(ICsvParserService<TimeRecordCSVInputMap, TimeRecordCSVInputDTO> csvParserService)
    {
        _csvParserService = csvParserService;
    }
    public List<TimeSheetClosureViewModel> GetTimeSheetClousure(string pathToDiretory)
    {
        var timeRecords = _csvParserService.getDataFromDirectoryAsync(pathToDiretory).GroupBy(c => c.Employee.Id).ToList();

        foreach (var employeeEntry in timeRecords)
        {
            foreach (var record in employeeEntry)
            {
                System.Console.WriteLine(record.FileName);
            }
        }

        return new List<TimeSheetClosureViewModel>();
    }
}