using System.ComponentModel.DataAnnotations;

namespace TesteAuvo.Application.Dtos;

public class TimeRecordCSVInputDTO
{
    [Display(Name = "Código")]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Display(Name = "Valor hora")]
    public double HourlyRate { get; set; }

    [Display(Name = "Data")]
    public DateOnly Date { get; set; }

    [Display(Name = "Entrada")]
    public TimeOnly EntryTime { get; set; }

    [Display(Name = "Saída")]
    public TimeOnly ExitTime { get; set; }
    
    [Display(Name = "Almoço")]
    public TimeOnly LunchPeriod { get; set; }
}