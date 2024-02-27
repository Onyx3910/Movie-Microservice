namespace Saga.Domain.Events
{
    public record TicketOrderSeatsSelected(
        Guid CorrelationId,
        string Seats,
        DateTime LastUpdatedDate);
}
