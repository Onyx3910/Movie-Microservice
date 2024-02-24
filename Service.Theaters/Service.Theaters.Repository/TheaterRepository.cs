using Service.Theaters.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Theaters.Repository
{
    public class TheaterRepository : ITheaterRepository
    {
        public List<Theater> GetAllTheaters()
        {
            return [.. Database.TheaterTable];
        }

        public List<Seat> GetSeatsByMovie(int movieId)
        {
            if (!Database.MovieTable.Any(movie => movie.Id == movieId)) return default;
            return Database.SeatTable.Where(seat => seat.MovieId == movieId).ToList();
        }

        public List<Movie> GetMoviesByTheater(int theaterId)
        {
            if (!Database.TheaterTable.Any(theater => theater.Id == theaterId)) return default;
            return Database.MovieTable.Where(movie => movie.TheaterId == theaterId).ToList();
        }

        public bool LockSeats(int movieId, List<SeatDto> seatDtos, Guid contextId, TimeSpan? duration = null)
        {
            if (!Database.MovieTable.Any(movie => movie.Id == movieId)) return false;
            var seats = Database.SeatTable.Where(seat => seatDtos.Any(seatDto => seatDto.Row == seat.Row &&
                                                         seatDto.SeatNumber == seat.SeatNumber &&
                                                         movieId == seat.MovieId)).ToList();
            foreach(var seat in seats)
            {
                if ((seat.IsTaken && seat.Lock + seat.LockDuration > DateTime.Now) || seat.ContextId != contextId) return false;
                seat.IsTaken = true;
                seat.Lock = DateTime.Now;
                seat.LockDuration = duration;
                seat.ContextId = contextId;
            }
            return true;
        }
    }
}
