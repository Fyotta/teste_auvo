using TesteAuvo.Domain.Abstractions;

namespace TesteAuvo.Domain.Entities;


public class TimeSheetClosure : Entity
{
    public Guid BookEmployeeTimeRecordId { get; private set; }
    public virtual BookEmployeeTimeRecord BookEmployeeTimeRecord { get; private set; }
    public double TotalPayment { get; private set; }
    public double TotalDeductions { get; private set; }
    public double TotalOvertime { get; private set; }
    public virtual ICollection<PaymentOrder>? PaymentOrders { get; set; }

    public TimeSheetClosure(Guid id, Guid bookEmployeeTimeRecordId, double totalPayment,
                                double totalDeductions, double totalOvertime) : base(id)
    {
        BookEmployeeTimeRecordId = bookEmployeeTimeRecordId;
        TotalPayment = totalPayment;
        TotalDeductions = totalDeductions;
        TotalOvertime = totalOvertime;
    }

    public TimeSheetClosure(Guid id, BookEmployeeTimeRecord bookEmployeeTimeRecord, double totalPayment,
                                double totalDeductions, double totalOvertime) : base(id)
    {
        BookEmployeeTimeRecord = bookEmployeeTimeRecord;
        BookEmployeeTimeRecordId = bookEmployeeTimeRecord.Id;
        TotalPayment = totalPayment;
        TotalDeductions = totalDeductions;
        TotalOvertime = totalOvertime;
    }
    public TimeSheetClosure(Guid id, BookEmployeeTimeRecord bookEmployeeTimeRecord) : base(id)
    {
        BookEmployeeTimeRecord = bookEmployeeTimeRecord;
        BookEmployeeTimeRecordId = bookEmployeeTimeRecord.Id;
    }

    public void CalculateTimeSheetClosure()
    {
        TotalPayment = PaymentOrders.Sum(c => c.TotalEarnings);
        TotalDeductions = PaymentOrders.Sum(c => c.MissingHoursDeduction);
        TotalOvertime = PaymentOrders.Sum(c => c.OvertimePayment);
    }
}