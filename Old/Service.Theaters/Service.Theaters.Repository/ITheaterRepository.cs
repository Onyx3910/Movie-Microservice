using Service.Theaters.Models.Common;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Service.Theaters.Repository
{
    public interface ITheaterRepository
    {
        List<Theater> GetAllTheaters();
        List<Movie> GetMoviesByTheater(int theaterId);
        List<Seat> GetSeatsByMovie(int movieId);
        bool LockSeats(int movieId, List<SeatDto> seatDtos, Guid contextId, TimeSpan? duration = null);
    }
}
