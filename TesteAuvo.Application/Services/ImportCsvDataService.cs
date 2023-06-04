using System.Globalization;
using Microsoft.Extensions.Configuration;
using TesteAuvo.Application.Dtos;
using TesteAuvo.Application.Interfaces;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Mapping;
using TesteAuvo.Domain.Entities;

namespace TesteAuvo.Application.Services;

public class ImportCsvDataService : IImportCsvDataService
{
    private readonly ICsvParserService<InputCsvPtBrTimeRecordMap, InputCsvTimeRecordDTO> _csvParserService;
    private readonly IConfiguration _configuration;
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;
    private readonly IBookEmployeeTimeRecordService _bookEmployeeTimeRecordService;
    private readonly IEmployeeTimeRecordService _employeeTimeRecordService;
    public ImportCsvDataService(ICsvParserService<InputCsvPtBrTimeRecordMap, InputCsvTimeRecordDTO> csvParserService,
                                    IConfiguration configuration,
                                    IEmployeeService employeeService,
                                    IDepartmentService departmentService,
                                    IBookEmployeeTimeRecordService bookEmployeeTimeRecordService,
                                    IEmployeeTimeRecordService employeeTimeRecordService)
    {
        _csvParserService = csvParserService;
        _configuration = configuration;
        _employeeService = employeeService;
        _departmentService = departmentService;
        _bookEmployeeTimeRecordService = bookEmployeeTimeRecordService;
        _employeeTimeRecordService = employeeTimeRecordService;
    }

    public async Task ImportCsvDataFromDiretoryAsync(string pathToDiretory)
    {
        List<InputCsvTimeRecordDTO> csvData = _csvParserService.getDataFromDirectoryAsync(pathToDiretory);

        foreach (var csvRecord in csvData)
        {
            Department? department = await _departmentService.FindByNameAsync(FileNameToDepartmentName(csvRecord.FileName));
            if (department == null)
            {
                department = new Department(Guid.NewGuid(), FileNameToDepartmentName(csvRecord.FileName));
                await _departmentService.AddAsync(department);
            }

            Employee? employee = await _employeeService.FindByExternalIdAsync(csvRecord.Employee.ExternalId);
            if (employee == null)
            {
                employee = new Employee(Guid.NewGuid(), csvRecord.Employee.ExternalId, csvRecord.Employee.Name);
                await _employeeService.AddAsync(employee);
            }

            BookEmployeeTimeRecord? bookEmployeeTimeRecord = await _bookEmployeeTimeRecordService.FindByBookReferenceAsync(department.Id, FileNameToEffectiveMonth(csvRecord.FileName), FileNameToEffectiveYear(csvRecord.FileName));
            if (bookEmployeeTimeRecord == null)
            {
                bookEmployeeTimeRecord = new BookEmployeeTimeRecord(Guid.NewGuid(), department.Id, FileNameToEffectiveMonth(csvRecord.FileName), FileNameToEffectiveYear(csvRecord.FileName));
                await _bookEmployeeTimeRecordService.AddAsync(bookEmployeeTimeRecord);
            }

            EmployeeTimeRecord employeeTimeRecord = new EmployeeTimeRecord(Guid.NewGuid(), employee.Id, csvRecord.HourlyRate,
                                                                                csvRecord.Date, csvRecord.EntryTime,
                                                                                csvRecord.ExitTime, csvRecord.LunchPeriodStart,
                                                                                csvRecord.LunchPeriodEnd, bookEmployeeTimeRecord.Id);
            await _employeeTimeRecordService.AddAsync(employeeTimeRecord);
        }
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