using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces;
using TesteAuvo.Infra.Data.Repositories.Abstractions;

namespace TesteAuvo.Infra.Data.Repositories;

public class PaymentOrderRepository : RepositoryBase<PaymentOrder>, IPaymentOrderRepository
{
    public PaymentOrderRepository(AppDbContext context) : base(context)
    {
    }
}