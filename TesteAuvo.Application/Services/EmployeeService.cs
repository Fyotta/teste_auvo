using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services.Abstractions;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces;

namespace TesteAuvo.Application.Services;

public class EmployeeService : ServiceBase<Employee>, IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    public EmployeeService(IEmployeeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Employee?> FindByExternalIdAsync(int externalId)
    {
        var result = await _repository.GetAsync();
        return result.FirstOrDefault(c => c.ExternalId == externalId);
    }
}