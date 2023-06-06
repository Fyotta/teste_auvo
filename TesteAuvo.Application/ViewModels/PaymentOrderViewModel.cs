using System.Text.Json.Serialization;

namespace TesteAuvo.Application.ViewModels;

public class PaymentOrderViewModel
{
    [JsonPropertyName("Nome")]
    public string  EmployeeName { get; set; }

    [JsonPropertyName("Codigo")]
    public int EmployeeId { get; set; }

    [JsonPropertyName("TotalReceber")]
    public double TotalEarnings { get; set; }

    [JsonPropertyName("HorasExtras")]
    public double OvertimeHours { get; set; }

    [JsonPropertyName("HorasDebito")]
    public double DebitHours { get; set; }

    [JsonPropertyName("DiasFalta")]
    public int AbsentDays { get; set; }

    [JsonPropertyName("DiasExtras")]
    public int ExtraDays { get; set; }

    [JsonPropertyName("DiasTrabalhados")]
    public int WorkedDays { get; set; }
}