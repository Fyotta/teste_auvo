using TesteAuvo.Application.Interfaces;
using TesteAuvo.Domain.Entities;

namespace TesteAuvo.Application.Dtos;

public class InputCsvTimeRecordDTO : ICsvData
{
    public Employee Employee { get; set; }
    public double HourlyRate { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly EntryTime { get; set; }
    public TimeOnly ExitTime { get; set; }
    public TimeOnly LunchPeriodStart { get; set; }
    public TimeOnly LunchPeriodEnd { get; set; }
    public string FileName { get; set; }
}