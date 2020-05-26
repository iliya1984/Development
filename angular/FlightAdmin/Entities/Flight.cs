using System;

namespace FlightAdmin.Entities
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string DepartureCode { get; set; }
        public string DestinationCode { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}