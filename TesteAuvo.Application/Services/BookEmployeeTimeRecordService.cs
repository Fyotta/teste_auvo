using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services.Abstractions;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces;

namespace TesteAuvo.Application.Services;

public class BookEmployeeTimeRecordService : ServiceBase<BookEmployeeTimeRecord>, IBookEmployeeTimeRecordService
{
    private readonly IBookEmployeeTimeRecordRepository _repository;
    public BookEmployeeTimeRecordService(IBookEmployeeTimeRecordRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<BookEmployeeTimeRecord?> FindByBookReferenceAsync(Guid departmentId, int effectiveMonth, int effectiveYear)
    {
        var result = await _repository.GetAsync();
        return result.FirstOrDefault(c => c.DepartmentId == departmentId &&
                                        c.EffectiveMonth == effectiveMonth &&
                                        c.EffectiveYear == effectiveYear);
    }
}