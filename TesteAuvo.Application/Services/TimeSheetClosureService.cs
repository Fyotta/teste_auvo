using TesteAuvo.Application.Dtos;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Mapping;
using TesteAuvo.Application.ViewModels;

namespace TesteAuvo.Application.Services;

public class TimeSheetClosureService : ITimeSheetClosureService
{

    private readonly ICsvParserService<TimeRecordCSVInputMap, TimeRecordCSVInputDTO> _csvParserService;
    public TimeSheetClosureService(ICsvParserService<TimeRecordCSVInputMap, TimeRecordCSVInputDTO> csvParserService)
    {
        _csvParserService = csvParserService;
    }
    public List<TimeRecordCSVInputDTO> AnalyzeDirectoryDataAsync(string pathToDiretory)
    {
        var myData = _csvParserService.getDataFromDirectoryAsync(pathToDiretory);
        return myData;
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