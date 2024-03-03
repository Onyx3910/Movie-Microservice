using eShop.Tickets.Bff.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Tickets.Bff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            await Task.FromResult(0);
            return Ok();
        }
    }
}
