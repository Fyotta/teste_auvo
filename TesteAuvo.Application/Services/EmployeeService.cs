using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services.Abstractions;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces.Abstractions;

namespace TesteAuvo.Application.Services;

public class EmployeeService : ServiceBase<Employee>, IEmployeeService
{
    public EmployeeService(IRepositoryBase<Employee> repository) : base(repository)
    {
    }
}