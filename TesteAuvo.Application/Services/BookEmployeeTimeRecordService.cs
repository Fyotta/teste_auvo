using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services.Abstractions;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces.Abstractions;

namespace TesteAuvo.Application.Services;

public class BookEmployeeTimeRecordService : ServiceBase<BookEmployeeTimeRecord>, IBookEmployeeTimeRecordService
{
    public BookEmployeeTimeRecordService(IRepositoryBase<BookEmployeeTimeRecord> repository) : base(repository)
    {
    }
}