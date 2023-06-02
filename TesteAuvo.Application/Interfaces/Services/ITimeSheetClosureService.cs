using TesteAuvo.Application.ViewModels;
namespace TesteAuvo.Application.Interfaces.Services;

public interface ITimeSheetClosureService
{
    public List<TimeSheetClosureViewModel> GetTimeSheetClousure(string pathToDiretory);
}