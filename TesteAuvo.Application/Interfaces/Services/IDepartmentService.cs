using TesteAuvo.Application.Interfaces.Services.Abstractions;
using TesteAuvo.Domain.Entities;

namespace TesteAuvo.Application.Interfaces.Services;

public interface IDepartmentService : IServiceBase<Department>
{
    public Task<Department?> FindByNameAsync(string departmentName);
}