namespace Saga.Domain.Events
{
    public record TicketOrderSeatsExpired(
        Guid CorrelationId,
        DateTime LastUpdatedDate);
}
