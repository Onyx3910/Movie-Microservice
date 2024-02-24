using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Theaters.Models.Requests;
using Service.Theaters.Repository;
using System;

namespace Service.Theaters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TheaterController(ILogger<TheaterController> logger, ITheaterRepository theaterService) : ControllerBase
    {
        private readonly ILogger<TheaterController> _logger = logger;
        private readonly ITheaterRepository _theaterService = theaterService;

        [HttpGet]
        [Route("Theater")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetTheaters()
        {
            _logger.LogInformation("Getting all theaters");
            return Ok(_theaterService.GetAllTheaters());
        }

        [HttpGet]
        [Route("Theater/{theaterId}/Movies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetMoviesByTheater(int theaterId)
        {
            _logger.LogInformation("Getting movies for theater {theaterId}", theaterId);
            var movies = _theaterService.GetMoviesByTheater(theaterId);
            if (movies == default) return NotFound();
            return Ok(movies);
        }

        [HttpGet]
        [Route("Theater{theaterId}/Movie/{movieId}/AvailableSeats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]   
        public IActionResult GetAvailableSeatsByMovie(int theaterId, int movieId)
        {
            _logger.LogInformation("Getting available seats for movie {movieId} in theater {theaterId}", movieId, theaterId);
            var seats = _theaterService.GetSeatsByMovie(movieId);
            if (seats == default) return NotFound();
            return Ok(seats);
        }

        [HttpPatch]
        [Route("Theater/{theaterId}/Movie/{movieId}/LockSeats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult LockSeats(int theaterId, int movieId, [FromBody] LockSeatsRequest request)
        {
            _logger.LogInformation("Locking {seatCount} seats for movie {movieId} in theater {theaterId}", request.Seats.Count, movieId, theaterId);
            if (!_theaterService.LockSeats(movieId, request.Seats, Guid.Empty, TimeSpan.FromSeconds(10))) return BadRequest();
            return Ok();
        }
    }
}
