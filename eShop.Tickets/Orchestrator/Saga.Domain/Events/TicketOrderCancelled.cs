namespace Saga.Domain.Events
{
    public record TicketOrderCancelled(
        Guid CorrelationId,
        DateTime LastUpdatedDate);
}
