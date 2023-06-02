using TesteAuvo.Domain.Abstractions;

namespace TesteAuvo.Domain.Entities;

public class Employee : Entity
{
    public int ExternalId { get; private set; }
    public string Name { get; private set; }
    public virtual ICollection<EmployeeTimeRecord> EmployeeTimeRecords { get; set; }

    public Employee(Guid id, int externalId, string name) : base(id)
    {
        ExternalId = externalId;
        Name = name;
    }
}