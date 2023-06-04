using TesteAuvo.Application.Interfaces.Services.Abstractions;
using TesteAuvo.Domain.Entities;

namespace TesteAuvo.Application.Interfaces.Services;

public interface IEmployeeService : IServiceBase<Employee>
{
    public Task<Employee?> FindByExternalIdAsync(int externalId);
}