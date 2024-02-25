using Service.Tickets.Models.Base;
using System;

namespace Service.Tickets.Models.Responses
{
    public class PaymentResponse : Audit
    {
        public Guid PaymentId { get; set; }
    }
}
