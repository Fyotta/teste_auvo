using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services.Abstractions;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces;

namespace TesteAuvo.Application.Services;

public class PaymentOrderService : ServiceBase<PaymentOrder>, IPaymentOrderService
{
    public PaymentOrderService(IPaymentOrderRepository repository) : base(repository)
    {
    }
}