using System.Collections.Generic;
using Service.Tickets.Models.Base;
using Service.Tickets.Models.Common;

namespace Service.Tickets.Models.Responses
{
    public class TheaterResponse : Audit
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
