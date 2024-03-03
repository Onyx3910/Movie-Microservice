using eShop.Tickets.Bff.Domain.Models;

namespace eShop.Tickets.Bff.Domain.Responses
{
    public class CreateOrderResponse
    {
        public Guid CorrelationId { get; set; }
        public IEnumerable<Seat>? TheaterSeats { get; set; }
    }
}
