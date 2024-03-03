namespace eShop.Tickets.Bff.Domain.Requests
{
    public class CreateOrderRequest
    {
        public Guid TheaterId { get; set; }
        public Guid MovieId { get; set; }
        public DateTime ShowTime { get; set; }
    }
}
