namespace TesteAuvo.Application.Interfaces.Services;


public interface ICsvParserService<T>
{
    public Task<List<T>> getDataFromDirectoryAsync(string pathToDiretory);
}