namespace Saga.Domain.Events
{
    public record TicketOrderPaymentRejected(
        Guid CorrelationId,
        DateTime LastUpdatedDate);
}
