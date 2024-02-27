using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Tickets.Domain.Models
{
public record Address(
    string Street,
    string City,
    string State,
    string Zip,
    string Country);
}
