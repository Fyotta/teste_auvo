using TesteAuvo.Application.Dtos;
using TesteAuvo.Application.ViewModels;
namespace TesteAuvo.Application.Interfaces.Services;

public interface ITimeSheetClosureService
{
    public List<TimeSheetClosureViewModel> GetTimeSheetClousure();
    public List<TimeRecordCSVInputDTO> AnalyzeDirectoryDataAsync(string pathToDiretory);
    public bool GetAnalysisStatus(Guid id);
}