using Service.Tickets.Models.Common;

namespace Service.Tickets.Models.Requests
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public Address BillingAddress { get; set; }
    }
}
