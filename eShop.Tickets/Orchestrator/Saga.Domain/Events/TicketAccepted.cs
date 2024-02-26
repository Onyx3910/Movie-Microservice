namespace Saga.Domain.Events
{
    public record TicketAccepted(Guid CorrelationId, DateTime CreationDate);
}
