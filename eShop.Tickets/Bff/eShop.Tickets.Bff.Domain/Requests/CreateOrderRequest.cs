namespace eShop.Tickets.Bff.Domain.Requests
{
    public record CreateOrderRequest(
        Guid TheaterId,
        Guid MovieId,
        DateTime ShowTime);
}
