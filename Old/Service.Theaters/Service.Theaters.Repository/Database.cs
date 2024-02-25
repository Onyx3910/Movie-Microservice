using System;
using System.Collections.Generic;

namespace Service.Theaters.Repository
{
    public static class Database
    {
        public static readonly List<Theater> TheaterTable =
        [
            new Theater { Id = 1, Name = "Theater 1", Address = "Address 1" },
            new Theater { Id = 2, Name = "Theater 2", Address = "Address 2" },
            new Theater { Id = 3, Name = "Theater 3", Address = "Address 3" },
        ];

        public static readonly List<Movie> MovieTable =
        [
            new Movie { Id = 1, TheaterId = 1, MovieTitle = "Movie 1", Showtime = new DateTime(2022, 12, 1, 18, 0, 0), Length = new TimeSpan(2, 0, 0) },
            new Movie { Id = 2, TheaterId = 1, MovieTitle = "Movie 2", Showtime = new DateTime(2022, 12, 1, 20, 0, 0), Length = new TimeSpan(2, 0, 0) },
            new Movie { Id = 3, TheaterId = 2, MovieTitle = "Movie 3", Showtime = new DateTime(2022, 12, 1, 18, 0, 0), Length = new TimeSpan(2, 0, 0) },
            new Movie { Id = 4, TheaterId = 2, MovieTitle = "Movie 4", Showtime = new DateTime(2022, 12, 1, 20, 0, 0), Length = new TimeSpan(2, 0, 0) },
            new Movie { Id = 5, TheaterId = 3, MovieTitle = "Movie 5", Showtime = new DateTime(2022, 12, 1, 18, 0, 0), Length = new TimeSpan(2, 0, 0) },
            new Movie { Id = 6, TheaterId = 3, MovieTitle = "Movie 6", Showtime = new DateTime(2022, 12, 1, 20, 0, 0), Length = new TimeSpan(2, 0, 0) },
        ];

        public static readonly List<Seat> SeatTable =
        [
            new Seat { Id = 1, MovieId = 1, Row = 'A', SeatNumber = 1, IsTaken = false },
            new Seat { Id = 2, MovieId = 1, Row = 'A', SeatNumber = 2, IsTaken = false },
            new Seat { Id = 3, MovieId = 1, Row = 'A', SeatNumber = 3, IsTaken = false },
            new Seat { Id = 4, MovieId = 1, Row = 'A', SeatNumber = 4, IsTaken = false },
            new Seat { Id = 5, MovieId = 1, Row = 'A', SeatNumber = 5, IsTaken = false },
            new Seat { Id = 6, MovieId = 1, Row = 'A', SeatNumber = 6, IsTaken = false },
            new Seat { Id = 7, MovieId = 1, Row = 'A', SeatNumber = 7, IsTaken = false },
            new Seat { Id = 8, MovieId = 1, Row = 'A', SeatNumber = 8, IsTaken = false },
            new Seat { Id = 9, MovieId = 1, Row = 'A', SeatNumber = 9, IsTaken = false },
            new Seat { Id = 10, MovieId = 1, Row = 'A', SeatNumber = 10, IsTaken = false },
            new Seat { Id = 11, MovieId = 2, Row = 'A', SeatNumber = 1, IsTaken = false },
            new Seat { Id = 12, MovieId = 2, Row = 'A', SeatNumber = 2, IsTaken = false },
            new Seat { Id = 13, MovieId = 2, Row = 'A', SeatNumber = 3, IsTaken = false },
            new Seat { Id = 14, MovieId = 2, Row = 'A', SeatNumber = 4, IsTaken = false },
            new Seat { Id = 15, MovieId = 2, Row = 'A', SeatNumber = 5, IsTaken = false },
            new Seat { Id = 16, MovieId = 2, Row = 'A', SeatNumber = 6, IsTaken = false },
            new Seat { Id = 17, MovieId = 2, Row = 'A', SeatNumber = 7, IsTaken = false },
            new Seat { Id = 18, MovieId = 2, Row = 'A', SeatNumber = 8, IsTaken = false },
            new Seat { Id = 19, MovieId = 2, Row = 'A', SeatNumber = 9, IsTaken = false },
            new Seat { Id = 20, MovieId = 2, Row = 'A', SeatNumber = 10, IsTaken = false },
            new Seat { Id = 21, MovieId = 3, Row = 'A', SeatNumber = 1, IsTaken = false },
            new Seat { Id = 22, MovieId = 3, Row = 'A', SeatNumber = 2, IsTaken = false },
            new Seat { Id = 23, MovieId = 3, Row = 'A', SeatNumber = 3, IsTaken = false },
            new Seat { Id = 24, MovieId = 3, Row = 'A', SeatNumber = 4, IsTaken = false },
            new Seat { Id = 25, MovieId = 3, Row = 'A', SeatNumber = 5, IsTaken = false },
            new Seat { Id = 26, MovieId = 3, Row = 'A', SeatNumber = 6, IsTaken = false },
            new Seat { Id = 27, MovieId = 3, Row = 'A', SeatNumber = 7, IsTaken = false },
            new Seat { Id = 28, MovieId = 3, Row = 'A', SeatNumber = 8, IsTaken = false },
            new Seat { Id = 29, MovieId = 3, Row = 'A', SeatNumber = 9, IsTaken = false },
            new Seat { Id = 30, MovieId = 3, Row = 'A', SeatNumber = 10, IsTaken = false },
            new Seat { Id = 31, MovieId = 4, Row = 'A', SeatNumber = 1, IsTaken = false },
            new Seat { Id = 32, MovieId = 4, Row = 'A', SeatNumber = 2, IsTaken = false },
            new Seat { Id = 33, MovieId = 4, Row = 'A', SeatNumber = 3, IsTaken = false },
            new Seat { Id = 34, MovieId = 4, Row = 'A', SeatNumber = 4, IsTaken = false },
            new Seat { Id = 35, MovieId = 4, Row = 'A', SeatNumber = 5, IsTaken = false },
            new Seat { Id = 36, MovieId = 4, Row = 'A', SeatNumber = 6, IsTaken = false },
            new Seat { Id = 37, MovieId = 4, Row = 'A', SeatNumber = 7, IsTaken = false },
            new Seat { Id = 38, MovieId = 4, Row = 'A', SeatNumber = 8, IsTaken = false },
            new Seat { Id = 39, MovieId = 4, Row = 'A', SeatNumber = 9, IsTaken = false },
            new Seat { Id = 40, MovieId = 4, Row = 'A', SeatNumber = 10, IsTaken = false },
            new Seat { Id = 41, MovieId = 5, Row = 'A', SeatNumber = 1, IsTaken = false },
            new Seat { Id = 42, MovieId = 5, Row = 'A', SeatNumber = 2, IsTaken = false },
            new Seat { Id = 43, MovieId = 5, Row = 'A', SeatNumber = 3, IsTaken = false },
            new Seat { Id = 44, MovieId = 5, Row = 'A', SeatNumber = 4, IsTaken = false },
            new Seat { Id = 45, MovieId = 5, Row = 'A', SeatNumber = 5, IsTaken = false },
            new Seat { Id = 46, MovieId = 5, Row = 'A', SeatNumber = 6, IsTaken = false },
            new Seat { Id = 47, MovieId = 5, Row = 'A', SeatNumber = 7, IsTaken = false },
            new Seat { Id = 48, MovieId = 5, Row = 'A', SeatNumber = 8, IsTaken = false },
            new Seat { Id = 49, MovieId = 5, Row = 'A', SeatNumber = 9, IsTaken = false },
            new Seat { Id = 50, MovieId = 5, Row = 'A', SeatNumber = 10, IsTaken = false },
            new Seat { Id = 51, MovieId = 6, Row = 'A', SeatNumber = 1, IsTaken = false },
            new Seat { Id = 52, MovieId = 6, Row = 'A', SeatNumber = 2, IsTaken = false },
            new Seat { Id = 53, MovieId = 6, Row = 'A', SeatNumber = 3, IsTaken = false },
            new Seat { Id = 54, MovieId = 6, Row = 'A', SeatNumber = 4, IsTaken = false },
            new Seat { Id = 55, MovieId = 6, Row = 'A', SeatNumber = 5, IsTaken = false },
            new Seat { Id = 56, MovieId = 6, Row = 'A', SeatNumber = 6, IsTaken = false },
            new Seat { Id = 57, MovieId = 6, Row = 'A', SeatNumber = 7, IsTaken = false },
            new Seat { Id = 58, MovieId = 6, Row = 'A', SeatNumber = 8, IsTaken = false },
            new Seat { Id = 59, MovieId = 6, Row = 'A', SeatNumber = 9, IsTaken = false },
            new Seat { Id = 60, MovieId = 6, Row = 'A', SeatNumber = 10, IsTaken = false },
        ];
    }
}
