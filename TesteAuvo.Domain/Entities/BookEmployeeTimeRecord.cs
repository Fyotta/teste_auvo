using TesteAuvo.Domain.Abstractions;

namespace TesteAuvo.Domain.Entities;

public class BookEmployeeTimeRecord : Entity
{
    public Guid DepartmentId { get; private set; }
    public virtual Department Department { get; private set; }
    public int EffectiveMonth { get; private set; }
    public int EffectiveYear { get; private set; }
    public virtual ICollection<EmployeeTimeRecord>? EmployeeTimeRecords { get; set; }
    public virtual TimeSheetClosure? TimeSheetClosure { get; set; }

    public BookEmployeeTimeRecord(Guid id, Guid departmentId, int effectiveMonth, int effectiveYear) : base(id)
    {
        DepartmentId = departmentId;
        EffectiveMonth = effectiveMonth;
        EffectiveYear = effectiveYear;
    }
    public BookEmployeeTimeRecord(Guid id, Department department, int effectiveMonth, int effectiveYear) : base(id)
    {
        DepartmentId = department.Id;
        Department = department;
        EffectiveMonth = effectiveMonth;
        EffectiveYear = effectiveYear;
    }
}