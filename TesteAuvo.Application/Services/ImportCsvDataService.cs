using System.Collections.Concurrent;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using TesteAuvo.Application.Dtos;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Mapping;
using TesteAuvo.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace TesteAuvo.Application.Services;

public class ImportCsvDataService : IImportCsvDataService
{
    private readonly ICsvParserService<InputCsvPtBrTimeRecordMap, InputCsvTimeRecordDTO> _csvParserService;
    private readonly IConfiguration _configuration;
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;
    private readonly IBookEmployeeTimeRecordService _bookEmployeeTimeRecordService;
    private readonly IEmployeeTimeRecordService _employeeTimeRecordService;
    private readonly ILogger<ImportCsvDataService> _logger;
    public ImportCsvDataService(ICsvParserService<InputCsvPtBrTimeRecordMap, InputCsvTimeRecordDTO> csvParserService,
                                    ILogger<ImportCsvDataService> logger,
                                    IConfiguration configuration,
                                    IEmployeeService employeeService,
                                    IDepartmentService departmentService,
                                    IBookEmployeeTimeRecordService bookEmployeeTimeRecordService,
                                    IEmployeeTimeRecordService employeeTimeRecordService)
    {
        _csvParserService = csvParserService;
        _logger = logger;
        _configuration = configuration;
        _employeeService = employeeService;
        _departmentService = departmentService;
        _bookEmployeeTimeRecordService = bookEmployeeTimeRecordService;
        _employeeTimeRecordService = employeeTimeRecordService;
    }

    public async Task ImportCsvDataFromDiretoryAsync(string pathToDiretory)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        _logger.LogInformation($"{DateTimeOffset.Now}: Carregando arquivos CSV...");
        List<InputCsvTimeRecordDTO> csvData = _csvParserService.getDataFromDirectoryAsync(pathToDiretory);

        _logger.LogInformation($"{DateTimeOffset.Now}: Analisando dados...");
        var departments = csvData
            .Select(c => FileNameToDepartmentName(c.FileName))
            .Distinct()
            .Select(c => {
                return new Department(Guid.NewGuid(), c);
            }).ToList();

        var employees = csvData
            .Select(c => c.Employee)
            .DistinctBy(c => c.ExternalId)
            .Select(c => {
                return new Employee(Guid.NewGuid(), c.ExternalId, c.Name);
            }).ToList();

        var bookEmployeeTimeRecords = csvData
            .Select(c => c.FileName)
            .Distinct()
            .Select(c => {
                var department = departments.FirstOrDefault(d => d.Name == FileNameToDepartmentName(c));
                return new BookEmployeeTimeRecord(Guid.NewGuid(), department, FileNameToEffectiveMonth(c), FileNameToEffectiveYear(c));
            }).ToList();

        var employeeTimeRecords = csvData
            .Select(c => {
                var employee = employees.FirstOrDefault(e => e.ExternalId == c.Employee.ExternalId);
                var bookEmployeeTimeRecord = bookEmployeeTimeRecords.FirstOrDefault(b => b.Department.Name == FileNameToDepartmentName(c.FileName) &&
                                                                                     b.EffectiveMonth == FileNameToEffectiveMonth(c.FileName) &&
                                                                                     b.EffectiveYear == FileNameToEffectiveYear(c.FileName));
                return new EmployeeTimeRecord(Guid.NewGuid(), employee.Id, c.HourlyRate,
                                                                c.Date, c.EntryTime,
                                                                c.ExitTime, c.LunchPeriodStart,
                                                                c.LunchPeriodEnd, bookEmployeeTimeRecord.Id);
            }).ToList();

        _logger.LogInformation($"{DateTimeOffset.Now}: Limpando dados obsoletos do banco de dados...");
        var dbBetr = await _bookEmployeeTimeRecordService.GetAsync();
        await _bookEmployeeTimeRecordService.DeleteRangeAsync(dbBetr);
        var dbEmployees = await _employeeService.GetAsync();
        await _employeeService.DeleteRangeAsync(dbEmployees);
        var dbDepartments = await _departmentService.GetAsync();
        await _departmentService.DeleteRangeAsync(dbDepartments);

        _logger.LogInformation($"{DateTimeOffset.Now}: Salvando informações no banco de dados...");
        await _departmentService.AddRangeAsync(departments);
        await _employeeService.AddRangeAsync(employees);
        await _bookEmployeeTimeRecordService.AddRangeAsync(bookEmployeeTimeRecords);
        await _employeeTimeRecordService.AddRangeAsync(employeeTimeRecords);
        stopwatch.Stop();
        TimeSpan elapsed = stopwatch.Elapsed;
        _logger.LogInformation($"{DateTimeOffset.Now}: Importação concluída em {elapsed.TotalSeconds}s!");
    }

    private string FileNameToDepartmentName(string fileName)
    {
        string[] parts = Path.GetFileName(fileName).Replace(".csv", "").Split('-');
        return parts[0].Trim();
    }
    private int FileNameToEffectiveMonth(string fileName)
    {
        string[] parts = Path.GetFileName(fileName).Replace(".csv", "").Split('-');
        return DateTime.ParseExact(parts[1], "MMMM", new CultureInfo(_configuration["CsvConfiguration:CultureInfo"])).Month;
    }
    private int FileNameToEffectiveYear(string fileName)
    {
        string[] parts = Path.GetFileName(fileName).Replace(".csv", "").Split('-');
        return int.Parse(parts[2]);
    }
}