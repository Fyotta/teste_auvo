using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using TesteAuvo.Application.Interfaces;
using TesteAuvo.Application.Interfaces.Services;

namespace TesteAuvo.Infra.Storage.Services;

public class CsvParserService<TMap, TEntity> : ICsvParserService<TMap, TEntity> where TEntity : ICsvData where TMap : ClassMap<TEntity>
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
        string[] csvFiles = Directory.GetFiles(pathToDiretory, "*.csv");

        if (!csvFiles.Any())
            throw new FileNotFoundException("Desculpe, nenhum arquivo .csv foi encontrado, verifique o diretório informado e tente novamente.");

        List<TEntity> combinedData = new List<TEntity>();

        Parallel.ForEach(csvFiles, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, csvFile =>
        {
            IEnumerable<TEntity> csvData = getDataFromFile(csvFile);
            lock (combinedData)
            {
                combinedData.AddRange(csvData);
            }
        });

        // foreach (var csvFile in csvFiles)
        // {
        //     IEnumerable<TEntity> csvData = getDataFromFile(csvFile);
        //     combinedData.AddRange(csvData);
        // }
        return combinedData;
    }
    private IEnumerable<TEntity> getDataFromFile(string pathToFile)
    {
        var config = new CsvConfiguration(CultureInfo.GetCultureInfo(_configuration["CsvConfiguration:CultureInfo"]))
        {
            Delimiter = _configuration["CsvConfiguration:Delimiter"],
            HasHeaderRecord = bool.Parse(_configuration["CsvConfiguration:HasHeaderRecord"])
        };

        using (var reader = new StreamReader(pathToFile))
        using (var csv = new CsvReader(reader, config))
        {
            csv.Context.RegisterClassMap<TMap>();
            var csvData = csv.GetRecords<TEntity>().ToList();
            csvData.ForEach(record => record.FileName = pathToFile);
            return csvData;
        }
    }
}