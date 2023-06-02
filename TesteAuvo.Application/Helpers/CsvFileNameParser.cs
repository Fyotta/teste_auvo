namespace TesteAuvo.Application.Helpers;

public class CsvFileNameParser
{
    public string DepartmentName { get; }
    public string Month { get; }
    public int Year { get; }

    public CsvFileNameParser(string fileName)
    {
        string[] parts = fileName.Split('-');
        DepartmentName = parts[0];
        Month = parts[1];
        Year = int.Parse(parts[2]);
    }
}