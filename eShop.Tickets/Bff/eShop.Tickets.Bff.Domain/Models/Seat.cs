using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Tickets.Bff.Domain.Models
{
    public record Seat(
        char Row,
        int Number,
        bool IsTaken)
    {
        public override string ToString()
        {
            return $"{Row}{Number}|{IsTaken}";
        }
    }
}
