using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Tickets.Models;
using Service.Tickets.Models.Requests;
using Service.Tickets.Models.Responses;
using System.Threading.Tasks;

namespace Service.Tickets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController(ILogger<TicketController> logger, IPublisher publisher) : ControllerBase
    {
        private readonly ILogger<TicketController> _logger = logger;
        private readonly IPublisher _publisher = publisher;

        [HttpGet]
        [Route("Theater/{id}")]
        [ProducesResponseType(typeof(TheaterResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RetrieveTheaterMovies(string id)
        {
            return await Task.FromResult(Ok(new TheaterResponse()));
        }

        [HttpPatch]
        [Route("Theater/{theaterId}/{movieId}/Seats")]
        [ProducesResponseType(typeof(SeatResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(SeatResponse), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<SeatResponse>> SelectSeats(string theaterId, string movieId, SeatRequest request)
        {

            return await Task.FromResult(Ok(new SeatResponse()));
        }

        [HttpPost]
        [Route("Payment")]
        [ProducesResponseType(typeof(PaymentResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaymentResponse>> SubmitPayment(PaymentRequest request)
        {
            return await Task.FromResult(CreatedAtAction("ProcessPayment", new PaymentResponse()));
        }
    }
}
