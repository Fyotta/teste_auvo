using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces;
using TesteAuvo.Infra.Data.Repositories.Abstractions;

namespace TesteAuvo.Infra.Data.Repositories;

public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {

    }
}