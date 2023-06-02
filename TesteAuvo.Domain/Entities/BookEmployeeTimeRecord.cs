using System.Globalization;

namespace TesteAuvo.Domain.Entities;

public class BookEmployeeTimeRecord
{
    public string DepartmentName { get; private set; }
    public int EffectiveMonth { get; private set; }
    public int EffectiveYear { get; private set; }

    public BookEmployeeTimeRecord(string fileName)
    {
        string[] parts = fileName.Split('-');
        DepartmentName = parts[0];
        EffectiveMonth = DateTime.ParseExact(parts[1], "MMMM", new CultureInfo("pt-BR")).Month;
        EffectiveYear = int.Parse(parts[2]);
    }
    public BookEmployeeTimeRecord(string departmentName, int effectiveMonth, int effectiveYear)
    {
        DepartmentName = departmentName;
        EffectiveMonth = effectiveMonth;
        EffectiveYear = effectiveYear;
    }
}