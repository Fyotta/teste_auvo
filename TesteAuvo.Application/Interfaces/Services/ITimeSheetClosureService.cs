using TesteAuvo.Application.ViewModels;
namespace TesteAuvo.Application.Interfaces.Services;

public interface ITimeSheetClosureService
{
    public List<TimeSheetClosureViewModel> GetTimeSheetClousure();
    public Guid AnalyzeDirectoryData(string pathToDiretory);
    public bool GetAnalysisStatus(Guid id);
}