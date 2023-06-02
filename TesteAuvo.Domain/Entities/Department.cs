using TesteAuvo.Domain.Abstractions;

namespace TesteAuvo.Domain.Entities;

public class Department : Entity
{
    public string Name { get; private set; }
    public virtual ICollection<EmployeeTimeRecord> EmployeeTimeRecords { get; set; }

    public Department(Guid id, string name) : base(id)
    {
        Name = name;
    }
}