using Service.Tickets.Models.Base;
using Service.Tickets.Models.Common;
using System.Collections.Generic;

namespace Service.Tickets.Models.Responses
{
    public class SeatResponse : Audit
    {
        public string TheaterId { get; set; }
        public IEnumerable<Seat> Seats { get; set; }
    }
}
