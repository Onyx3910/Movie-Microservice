using eShop.Tickets.Bff.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Tickets.Bff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : Controller
    {
        [HttpPost]
        public async Task CreateOrder(CreateOrderRequest request)
        {

        }
    }
}
