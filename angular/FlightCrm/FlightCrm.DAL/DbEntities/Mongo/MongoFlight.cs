namespace FlightCrm.DAL.DbEntities.Mongo
{
    public class MongoFlight
    {
        public string id { get; set;}
        public string flightNumber { get; set; }
        public string destinationCode { get; set;}
        public string departureCode { get; set;}
        public string departureDate { get; set; }
        public string returnDate { get; set;}

    }
}