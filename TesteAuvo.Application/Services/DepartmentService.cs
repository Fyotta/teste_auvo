using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services.Abstractions;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces.Abstractions;

namespace TesteAuvo.Application.Services;

public class DepartmentService : ServiceBase<Department>, IDepartmentService
{
    private readonly IRepositoryBase<Department> _repository;
    public DepartmentService(IRepositoryBase<Department> repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Department?> FindByNameAsync(string departmentName)
    {
        var result = await _repository.GetAsync();
        return result.FirstOrDefault(c => c.Name == departmentName);
    }
}