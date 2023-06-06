using TesteAuvo.Domain.Abstractions;

namespace TesteAuvo.Domain.Entities;

public class PaymentOrder : Entity
{
    public Guid EmployeeId { get; private set; }
    public virtual Employee  Employee { get; private set; }
    public double TotalEarnings { get; private set; }
    public double OvertimeHours { get; private set; }
    public double OvertimePayment { get; private set; }
    public double DebitHours { get; private set; }
    public double MissingHoursDeduction { get; private set; }
    public int AbsentDays { get; private set; }
    public int ExtraDays { get; private set; }
    public int WorkedDays { get; private set; }
    public Guid TimeSheetClosureId { get; private set; }
    public virtual TimeSheetClosure TimeSheetClosure { get; private set; }
    

    public PaymentOrder(Guid id, Guid employeeId, Guid timeSheetClosureId,
                            double totalEarnings, double overtimeHours, double overtimePayment,
                            double debitHours, double missingHoursDeduction, int absentDays, int extraDays,
                            int workedDays) : base(id)
    {
        EmployeeId = employeeId;
        TotalEarnings = totalEarnings;
        OvertimeHours = overtimeHours;
        OvertimePayment = overtimePayment;
        DebitHours = debitHours;
        MissingHoursDeduction = missingHoursDeduction;
        AbsentDays = absentDays;
        ExtraDays = extraDays;
        WorkedDays = workedDays;
        TimeSheetClosureId = timeSheetClosureId;
    }

    public PaymentOrder(Guid id, Employee employee, TimeSheetClosure timeSheetClosure,
                            double totalEarnings, double overtimeHours, double overtimePayment,
                            double debitHours, double missingHoursDeduction, int absentDays,
                            int extraDays, int workedDays) : base(id)
    {
        Employee = employee;
        EmployeeId = employee.Id;
        TotalEarnings = totalEarnings;
        OvertimeHours = overtimeHours;
        OvertimePayment = overtimePayment;
        DebitHours = debitHours;
        MissingHoursDeduction = missingHoursDeduction;
        AbsentDays = absentDays;
        ExtraDays = extraDays;
        WorkedDays = workedDays;
        TimeSheetClosure = timeSheetClosure;
        TimeSheetClosureId = timeSheetClosure.Id;
    }
    public PaymentOrder(Guid id, Employee employee, TimeSheetClosure timeSheetClosure) : base(id)
    {
        Employee = employee;
        EmployeeId = employee.Id;
        TimeSheetClosure = timeSheetClosure;
        TimeSheetClosureId = timeSheetClosure.Id;
    }

    public void CalculatePaymentOrder()
    {
        var bookEmployeeTimeRecord = TimeSheetClosure.BookEmployeeTimeRecord;
        var employeeTimeRecords = bookEmployeeTimeRecord.EmployeeTimeRecords.Where(c => c.Employee == Employee).ToList();
        employeeTimeRecords ??= new List<EmployeeTimeRecord>();

        var lastDayOfMonth = DateTime.DaysInMonth(bookEmployeeTimeRecord.EffectiveYear, bookEmployeeTimeRecord.EffectiveMonth);
        double workingMinutes = 8 * 60;
        for (int day = 1; day <= lastDayOfMonth; day++)
        {
            var date = new DateOnly(bookEmployeeTimeRecord.EffectiveYear, bookEmployeeTimeRecord.EffectiveMonth, day);
            DayOfWeek dayOfWeek = date.DayOfWeek;
            bool isWeekday = dayOfWeek >= DayOfWeek.Monday && dayOfWeek <= DayOfWeek.Friday;
            var workedDay = employeeTimeRecords.LastOrDefault(c => c.Date == date);

            if (workedDay == null)
                if (isWeekday)
                {
                    AbsentDays++;
                    DebitHours+= workingMinutes / 60;
                    var lastWorkedDay = employeeTimeRecords.OrderByDescending(c => c.Date).FirstOrDefault();
                    if (lastWorkedDay != null)
                    {
                        MissingHoursDeduction+= workingMinutes * (lastWorkedDay.HourlyRate / 60);
                    }
                    else
                    {
                        MissingHoursDeduction = 0;
                    }
                    continue;
                }
                else
                {
                    continue;
                }

            WorkedDays++;
            var lunchBreakTaken = workedDay.LunchPeriodStart != new TimeOnly(0,0) && workedDay.LunchPeriodEnd != new TimeOnly(0,0);
            TimeSpan totalWorked;
            if (!isWeekday && !lunchBreakTaken)
            {
                totalWorked = workedDay.ExitTime - workedDay.EntryTime;
            }
            else
            {
                TimeSpan morningPeriod = workedDay.LunchPeriodStart - workedDay.EntryTime;
                TimeSpan afternoonPeriod = workedDay.ExitTime - workedDay.LunchPeriodEnd;
                totalWorked = morningPeriod + afternoonPeriod;
            }

            TotalEarnings+= totalWorked.TotalMinutes * (workedDay.HourlyRate / 60);
            
            if (!isWeekday)
            {
                ExtraDays++;
                OvertimePayment+= totalWorked.TotalMinutes * (workedDay.HourlyRate / 60);
                OvertimeHours+= totalWorked.TotalHours;
                continue;
            }            
            
            if (totalWorked.TotalMinutes > workingMinutes)
            {
                double minuteDifference = (totalWorked.TotalMinutes - workingMinutes);
                OvertimeHours+= minuteDifference / 60;
                OvertimePayment+= minuteDifference * (workedDay.HourlyRate / 60);
            }
            else if (totalWorked.TotalMinutes < workingMinutes)
            {
                double minuteDifference = (workingMinutes - totalWorked.TotalMinutes);
                DebitHours+= minuteDifference / 60;
                MissingHoursDeduction+= minuteDifference * (workedDay.HourlyRate / 60);
            }
        }
    }
}