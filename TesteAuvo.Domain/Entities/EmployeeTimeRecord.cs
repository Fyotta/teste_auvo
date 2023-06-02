namespace TesteAuvo.Domain.Entities;

public class EmployeeTimeRecord
{
    public Employee Employee { get; set; }
    public double HourlyRate { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly EntryTime { get; set; }
    public TimeOnly ExitTime { get; set; }
    public TimeOnly LunchPeriodStart { get; set; }
    public TimeOnly LunchPeriodEnd { get; set; }
    public Department Department { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
}