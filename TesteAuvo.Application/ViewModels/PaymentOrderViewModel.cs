using System.ComponentModel.DataAnnotations;

namespace TesteAuvo.Application.ViewModels;

public class PaymentOrderViewModel
{
    [Display(Name = "Nome")]
    public string  EmployeeName { get; set; }

    [Display(Name = "Codigo")]
    public string EmployeeId { get; set; }

    [Display(Name = "TotalReceber")]
    public double TotalEarnings { get; set; }

    [Display(Name = "HorasExtras")]
    public double OvertimeHours { get; set; }

    [Display(Name = "HorasDebito")]
    public double DebitHours { get; set; }

    [Display(Name = "DiasFalta")]
    public int AbsentDays { get; set; }

    [Display(Name = "DiasExtras")]
    public int ExtraDays { get; set; }

    [Display(Name = "DiasTrabalhados")]
    public int WorkedDays { get; set; }
}