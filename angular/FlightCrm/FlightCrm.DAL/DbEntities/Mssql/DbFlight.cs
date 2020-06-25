using System;

namespace FlightCrm.DAL.DbEntities.Mssql
{
    public class DbFlight
    {
        public int Pkid { get; set;}
        public string FlightNumber { get; set; }
        public string DestinationCode { get; set;}
        public string DepartureCode { get; set;}
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set;}

    }
}