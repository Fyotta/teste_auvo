using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services.Abstractions;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces.Abstractions;

namespace TesteAuvo.Application.Services;

public class EmployeeTimeRecordService : ServiceBase<EmployeeTimeRecord>, IEmployeeTimeRecordService
{
    public EmployeeTimeRecordService(IRepositoryBase<EmployeeTimeRecord> repository) : base(repository)
    {
    }
}