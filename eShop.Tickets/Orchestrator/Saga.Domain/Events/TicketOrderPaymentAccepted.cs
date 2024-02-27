namespace Saga.Domain.Events
{
    public record TicketOrderPaymentAccepted(
        Guid CorrelationId,
        DateTime LastUpdatedDate);
}
