using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services.Abstractions;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces.Abstractions;

namespace TesteAuvo.Application.Services;

public class DepartmentService : ServiceBase<Department>, IDepartmentService
{
    public DepartmentService(IRepositoryBase<Department> repository) : base(repository)
    {
    }
}