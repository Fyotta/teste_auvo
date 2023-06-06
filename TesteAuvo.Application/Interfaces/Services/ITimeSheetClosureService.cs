using TesteAuvo.Application.Interfaces.Services.Abstractions;
using TesteAuvo.Application.ViewModels;
using TesteAuvo.Domain.Entities;

namespace TesteAuvo.Application.Interfaces.Services;

public interface ITimeSheetClosureService : IServiceBase<TimeSheetClosure>
{
    public Task<IEnumerable<TimeSheetClosureViewModel>> GetTimeSheetClosureJson();
}