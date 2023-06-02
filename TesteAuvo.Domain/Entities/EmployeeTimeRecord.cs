using TesteAuvo.Domain.Abstractions;

namespace TesteAuvo.Domain.Entities;

public class EmployeeTimeRecord : Entity
{
    public double HourlyRate { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeOnly EntryTime { get; private set; }
    public TimeOnly ExitTime { get; private set; }
    public TimeOnly LunchPeriodStart { get; private set; }
    public TimeOnly LunchPeriodEnd { get; private set; }
    public int EffectiveMonth { get; private set; }
    public int EffectiveYear { get; private set; }
    public Guid EmployeeId { get; private set; }
    public virtual Employee Employee { get; private set; }
    public Guid DepartmentId { get; private set; }
    public virtual Department Department { get; private set; }

    public EmployeeTimeRecord(Guid id, Guid employeeId, double hourlyRate,
                                DateOnly date, TimeOnly entryTime, TimeOnly exitTime,
                                TimeOnly lunchPeriodStart, TimeOnly lunchPeriodEnd,
                                Guid departmentId, int effectiveMonth, int effectiveYear) : base(id)
    {
        EmployeeId = employeeId;
        HourlyRate = hourlyRate;
        Date = date;
        EntryTime = entryTime;
        ExitTime = exitTime;
        LunchPeriodStart = lunchPeriodStart;
        LunchPeriodEnd = lunchPeriodEnd;
        DepartmentId = departmentId;
        EffectiveMonth = effectiveMonth;
        EffectiveYear = effectiveYear;
    }
}