namespace TesteAuvo.Application.ViewModels;

public class PaymentOrderViewModel
{
    public string Nome { get; set; }
    public string Codigo { get; set; }
    public double TotalReceber { get; set; }
    public double HorasExtras { get; set; }
    public double HorasDebito { get; set; }
    public int DiasFalta { get; set; }
    public int DiasExtras { get; set; }
    public int DiasTrabalhados { get; set; }
}