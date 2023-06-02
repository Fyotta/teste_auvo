using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using TesteAuvo.Application.Interfaces;
using TesteAuvo.Application.Interfaces.Services;

namespace TesteAuvo.Infra.Storage.Services;

public class CsvParserService<TMap, TEntity> : ICsvParserService<TMap, TEntity> where TMap : ClassMap<TEntity> where TEntity : ICsvData
{
    private readonly IConfiguration _configuration;

    public CsvParserService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<TEntity> getDataFromDirectoryAsync(string pathToDiretory){
        if (!Directory.Exists(pathToDiretory))
            throw new DirectoryNotFoundException("O diretório informado é inválido! Por favor, verifique e tente novamente.");
            
        return getDataFromFiles(pathToDiretory);
    }
    private List<TEntity> getDataFromFiles(string pathToDiretory)
    {
        // TODO: VALIDAR DIRETÓRIO VAZIO
        string[] csvFiles = Directory.GetFiles(pathToDiretory, "*.csv");

        List<TEntity> combinedData = new List<TEntity>();

        foreach (var csvFile in csvFiles)
        {
            IEnumerable<TEntity> csvData = getDataFromFile(csvFile);
            combinedData.AddRange(csvData);
        }
        return combinedData;
    }
    private IEnumerable<TEntity> getDataFromFile(string pathToFile)
    {
        var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.GetCultureInfo(_configuration["CsvConfiguration:CultureInfo"]))
        {
            Delimiter = _configuration["CsvConfiguration:Delimiter"],
            HasHeaderRecord = bool.Parse(_configuration["CsvConfiguration:HasHeaderRecord"])
        };

        using (var reader = new StreamReader(pathToFile))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<TMap>();
            var csvData = csv.GetRecords<TEntity>().ToList();
            foreach (var record in csvData)
            {
                record.FileName = pathToFile;
            }
            return csvData;
        }
    }
}