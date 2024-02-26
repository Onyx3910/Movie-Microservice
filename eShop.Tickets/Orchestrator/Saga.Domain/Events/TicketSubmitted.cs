namespace Saga.Domain.Events
{
    public record TicketSubmitted(Guid CorrelationId, DateTime CreationDate);
}
