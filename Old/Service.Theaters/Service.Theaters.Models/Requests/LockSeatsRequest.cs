using Service.Theaters.Models.Common;
using System.Collections.Generic;

namespace Service.Theaters.Models.Requests
{
    public class LockSeatsRequest
    {
        public List<SeatDto> Seats { get; set; }
    }
}
