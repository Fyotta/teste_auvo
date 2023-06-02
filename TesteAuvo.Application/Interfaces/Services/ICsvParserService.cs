namespace TesteAuvo.Application.Interfaces.Services;


public interface ICsvParserService<TMap, TEntity>
{
    public List<TEntity> getDataFromDirectoryAsync(string pathToDiretory);
}