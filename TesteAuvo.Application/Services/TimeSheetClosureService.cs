using System.Globalization;
using Microsoft.Extensions.Configuration;
using TesteAuvo.Application.Dtos;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Mapping;
using TesteAuvo.Application.ViewModels;
using TesteAuvo.Domain.Entities;

namespace TesteAuvo.Application.Services;

public class TimeSheetClosureService : ITimeSheetClosureService
{

    private readonly ICsvParserService<InputCsvPtBrTimeRecordMap, InputCsvTimeRecordDTO> _csvParserService;
    private readonly IConfiguration _configuration;
    public TimeSheetClosureService(ICsvParserService<InputCsvPtBrTimeRecordMap, InputCsvTimeRecordDTO> csvParserService, IConfiguration configuration)
    {
        _csvParserService = csvParserService;
        _configuration = configuration;
    }
    public List<TimeSheetClosureViewModel> GetTimeSheetClousure(string pathToDiretory)
    {
        var timeRecords = _csvParserService.getDataFromDirectoryAsync(pathToDiretory).ToList();

        var employees = timeRecords
            .GroupBy(employee => employee.Employee.ExternalId)
            .Select(group => group.First().Employee)
            .ToList();

        var files = timeRecords
            .GroupBy(department => department.FileName)
            .Select(group => group.First().FileName)
            .Select(file => Path.GetFileName(file).Replace(".csv",""))
            .ToList();

        var departmentNames = files
            .Select(c => fileNameToDepartmentName(c))
            .Distinct()
            .ToList();

        foreach (var item in timeRecords)
        {
            System.Console.WriteLine(item.HourlyRate);
        }

        return new List<TimeSheetClosureViewModel>();
    }
    private BookEmployeeTimeRecord fileNameToBookEmployeeTimeRecord(string fileName)
    {
        string[] parts = fileName.Split('-');
        int effectiveMonth = DateTime.ParseExact(parts[1], "MMMM", new CultureInfo(_configuration["CsvConfiguration:CultureInfo"])).Month;
        int effectiveYear = int.Parse(parts[2]);
        var department = new Department(Guid.NewGuid(), parts[0]);
        return new BookEmployeeTimeRecord(Guid.NewGuid(), department.Id, effectiveMonth, effectiveYear);
    }

    private string fileNameToDepartmentName(string fileName)
    {
        string[] parts = fileName.Split('-');
        return parts[0].Trim();
    }

}