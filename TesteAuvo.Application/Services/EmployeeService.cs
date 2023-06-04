using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services.Abstractions;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces.Abstractions;

namespace TesteAuvo.Application.Services;

public class EmployeeService : ServiceBase<Employee>, IEmployeeService
{
    private readonly IRepositoryBase<Employee> _repository;
    public EmployeeService(IRepositoryBase<Employee> repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Employee?> FindByExternalIdAsync(int externalId)
    {
        var result = await _repository.GetAsync();
        return result.FirstOrDefault(c => c.ExternalId == externalId);
    }
}