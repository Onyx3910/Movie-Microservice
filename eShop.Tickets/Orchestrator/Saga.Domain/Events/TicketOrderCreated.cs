namespace Saga.Domain.Events
{
    public record TicketOrderCreated(
        Guid CorrelationId,
        Guid TheaterId,
        Guid MovieId,
        DateTime Showtime,
        DateTime CreationDate);
}
