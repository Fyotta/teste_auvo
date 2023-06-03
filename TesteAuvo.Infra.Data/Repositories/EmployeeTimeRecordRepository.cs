using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces;
using TesteAuvo.Infra.Data.Repositories.Abstractions;

namespace TesteAuvo.Infra.Data.Repositories;

public class EmployeeTimeRecordRepository : RepositoryBase<EmployeeTimeRecord>, IEmployeeTimeRecordRepository
{
    public EmployeeTimeRecordRepository(AppDbContext context) : base(context)
    {
    }
}