using System;
using System.Collections.Generic;

namespace Service.Tickets.Models.Common
{
    public class Movie
    {
        public string MovieTitle { get; set; }
        public DateTime Showtime { get; set; }
        public TimeSpan Length { get; set; }
        public Dictionary<char, IEnumerable<bool>> Seats { get; set; }
    }
}
