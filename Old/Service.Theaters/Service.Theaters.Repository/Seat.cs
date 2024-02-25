using System;

namespace Service.Theaters.Repository
{
    public class Seat
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public char Row { get; set; }
        public int SeatNumber { get; set; }
        public bool IsTaken { get; set; }
        public DateTime? Lock { get; set; }
        public TimeSpan? LockDuration { get; set; }
        public Guid ContextId { get; set; }
    }
}
