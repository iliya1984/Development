using System;

namespace FlightCrm.Entities
{
    public class Flight
    {
        public int Id { get; set;}
        public string FlightNumber { get; set; }
        public string DestinationCode { get; set;}
        public string DepartureCode { get; set;}
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set;}
    }
}
