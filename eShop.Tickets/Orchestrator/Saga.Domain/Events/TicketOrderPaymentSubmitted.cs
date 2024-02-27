using eShop.Tickets.Domain;

namespace Saga.Domain.Events
{
    public record TicketOrderPaymentSubmitted(
        Guid CorrelationId,
        DateTime LastUpdatedDate,
        decimal Total,
        CreditCardPayment Payment);
}
