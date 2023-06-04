using TesteAuvo.Application.Interfaces.Services.Abstractions;
using TesteAuvo.Domain.Entities;

namespace TesteAuvo.Application.Interfaces.Services;

public interface IBookEmployeeTimeRecordService : IServiceBase<BookEmployeeTimeRecord>
{
    public Task<BookEmployeeTimeRecord?> FindByBookReferenceAsync(Guid departmentId, int effectiveMonth, int effectiveYear);
}