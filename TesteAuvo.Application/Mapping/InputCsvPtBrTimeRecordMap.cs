using System.Globalization;
using CsvHelper.Configuration;
using TesteAuvo.Application.Dtos;
using TesteAuvo.Application.Interfaces;
using TesteAuvo.Domain.Entities;

namespace TesteAuvo.Application.Mapping;

public class InputCsvPtBrTimeRecordMap : ClassMap<InputCsvTimeRecordDTO>
{
    public InputCsvPtBrTimeRecordMap()
    {
        Map(m => m.Employee).Convert(row =>
        {
            int externalId = row.Row.GetField<int>("Código");
            string name = row.Row.GetField<string>("Nome");
            return new Employee(Guid.NewGuid(), externalId, name);
        });
        Map(m => m.HourlyRate).Name("Valor hora").Convert(row =>
        {
            string hourlyRate = row.Row.GetField<string>("Valor hora");
            return double.Parse(hourlyRate.Replace("R$", "").Trim(), CultureInfo.GetCultureInfo("pt-BR"));
        });
        Map(m => m.Date).Name("Data").TypeConverterOption.Format("dd/MM/yyyy");
        Map(m => m.EntryTime).Name("Entrada").TypeConverterOption.Format("HH:mm:ss");
        Map(m => m.ExitTime).Name("Saída").TypeConverterOption.Format("HH:mm:ss");
        Map(m => m.LunchPeriodStart).Name("Almoço").Convert(row =>
        {
            string lunchPeriod = row.Row.GetField("Almoço");
            string[] time = lunchPeriod.Split('-');
            return TimeOnly.Parse(time[0].Trim());
        });
        Map(m => m.LunchPeriodEnd).Name("Almoço").Convert(row =>
        {
            string lunchPeriod = row.Row.GetField("Almoço");
            string[] time = lunchPeriod.Split('-');
            return TimeOnly.Parse(time[1].Trim());
        });
    }
}