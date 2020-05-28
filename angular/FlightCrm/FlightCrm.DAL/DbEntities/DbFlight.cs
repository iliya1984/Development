using System;

namespace FlightCrm.DAL.DbEntities
{
    public class DbFlight
    {
        public int Id { get; set;}
        public string FlightNumber { get; set; }
        public string DestinationCode { get; set;}
        public string DepartureCode { get; set;}
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set;}

    }
}