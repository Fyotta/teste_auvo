using System.ComponentModel.DataAnnotations;

namespace TesteAuvo.Application.ViewModels;

public class TimeSheetClosureViewModel
{
    [Display(Name = "Departamento")]
    public string Department { get; set; }

    [Display(Name = "MesVigencia")]
    public string EffectiveMonth { get; set; }

    [Display(Name = "AnoVigencia")]
    public int EffectiveYear { get; set; }

    [Display(Name = "TotalPagar")]
    public double TotalPayment { get; set; }

    [Display(Name = "TotalDescontos")]
    public double TotalDeductions { get; set; }

    [Display(Name = "TotalExtras")]
    public double TotalOvertime { get; set; }

    [Display(Name = "Funcionarios")]
    public List<PaymentOrderViewModel> Employees { get; set; }
}