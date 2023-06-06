using System.Text.Json.Serialization;

namespace TesteAuvo.Application.ViewModels;

public class TimeSheetClosureViewModel
{
    [JsonPropertyName("Departamento")]
    public string DepartmentName { get; set; }

    [JsonPropertyName("MesVigencia")]
    public string EffectiveMonth { get; set; }

    [JsonPropertyName("AnoVigencia")]
    public int EffectiveYear { get; set; }

    [JsonPropertyName("TotalPagar")]
    public double TotalPayment { get; set; }

    [JsonPropertyName("TotalDescontos")]
    public double TotalDeductions { get; set; }

    [JsonPropertyName("TotalExtras")]
    public double TotalOvertime { get; set; }

    [JsonPropertyName("Funcionarios")]
    public List<PaymentOrderViewModel> Employees { get; set; }
}