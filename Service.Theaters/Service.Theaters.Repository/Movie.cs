using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Theaters.Repository
{
    public class Movie
    {
        public int Id { get; set; }
        public int TheaterId { get; set; }
        public string MovieTitle { get; set; }
        public DateTime Showtime { get; set; }
        public TimeSpan Length { get; set; }
    }
}
