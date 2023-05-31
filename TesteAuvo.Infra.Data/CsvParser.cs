using System.Globalization;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using TesteAuvo.Application.Interfaces.Services;

namespace TesteAuvo.Infra.Data;

public class CsvParser<T> : ICsvParserService<T>
{
    private readonly IConfiguration _configuration;

    public CsvParser(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<T>> getDataFromDirectoryAsync(string pathToDiretory){
        if (!Directory.Exists(pathToDiretory))
            throw new DirectoryNotFoundException("O diretório informado é inválido! Por favor, verifique e tente novamente.");
            
        return await getDataFromFiles(pathToDiretory);
    }
    private Task<List<T>> getDataFromFiles(string pathToDiretory)
    {
        // TODO: VALIDAR DIRETÓRIO VAZIO
        string[] csvFiles = Directory.GetFiles(pathToDiretory, "*.csv");

        List<T> combinedData = new List<T>();

        var tasks = csvFiles.Select((csvFile) =>
        {
            return Task.Factory.StartNew(() =>
            {
                IEnumerable<T> csvData = getDataFromFile(csvFile);
                combinedData.AddRange(csvData);
            });
        });
        
        return Task.WhenAll(tasks).ContinueWith((task) => {
            return combinedData;
        });
    }
    private IEnumerable<T> getDataFromFile(string pathToFile)
    {
        var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.GetCultureInfo(_configuration["CsvConfiguration:CultureInfo"]))
        {
            Delimiter = _configuration["CsvConfiguration:Delimiter"],
            HasHeaderRecord = bool.Parse(_configuration["CsvConfiguration:HasHeaderRecord"])
        };
        using (var reader = new StreamReader(pathToFile))
        using (var csv = new CsvReader(reader, config))
            return csv.GetRecords<T>();
    }
}