using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces;
using TesteAuvo.Infra.Data.Repositories.Abstractions;

namespace TesteAuvo.Infra.Data.Repositories;

public class TimeSheetClosureRepository : RepositoryBase<TimeSheetClosure>, ITimeSheetClosureRepository
{
    public TimeSheetClosureRepository(AppDbContext context) : base(context)
    {
    }
}