namespace TesteAuvo.Application.Interfaces.Services;


public interface IImportCsvDataService
{
    public Task ImportCsvDataFromDiretoryAsync(string pathToDiretory);
}