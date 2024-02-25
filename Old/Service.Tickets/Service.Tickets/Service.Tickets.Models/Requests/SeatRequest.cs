using Service.Tickets.Models.Base;
using Service.Tickets.Models.Common;
using System.Collections.Generic;

namespace Service.Tickets.Models.Requests
{
    public class SeatRequest : Audit
    {    
        public string TheaterId { get; set; }
        public string MovieId { get; set; }
        public IEnumerable<Seat> Seats { get; set; }
    }
}
