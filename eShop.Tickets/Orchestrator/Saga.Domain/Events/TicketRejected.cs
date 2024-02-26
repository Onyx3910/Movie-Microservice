namespace Saga.Domain.Events
{
    public record TicketRejected(Guid CorrelationId, DateTime CreationDate);
}
