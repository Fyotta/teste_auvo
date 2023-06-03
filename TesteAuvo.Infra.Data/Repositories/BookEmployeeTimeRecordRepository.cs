using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces;
using TesteAuvo.Infra.Data.Repositories.Abstractions;

namespace TesteAuvo.Infra.Data.Repositories;

public class BookEmployeeTimeRecordRepository : RepositoryBase<BookEmployeeTimeRecord>, IBookEmployeeTimeRecordRepository
{
    public BookEmployeeTimeRecordRepository(AppDbContext context) : base(context)
    {
    }
}