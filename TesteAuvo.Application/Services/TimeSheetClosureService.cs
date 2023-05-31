using TesteAuvo.Application.Dtos;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.ViewModels;

namespace TesteAuvo.Application.Services;

public class TimeSheetClosureService : ITimeSheetClosureService
{

    private readonly ICsvParserService<TimeRecordCSVInputDTO> _csvParserService;
    public TimeSheetClosureService(ICsvParserService<TimeRecordCSVInputDTO> csvParserService)
    {
        _csvParserService = csvParserService;
    }
    public Guid AnalyzeDirectoryData(string pathToDiretory)
    {
        throw new NotImplementedException();
    }

    public bool GetAnalysisStatus(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<TimeSheetClosureViewModel> GetTimeSheetClousure()
    {
        throw new NotImplementedException();
    }
}