namespace FlightCrm.Entities
{
    public class FlightRequest
    {
        public int Id { get; set;}
        public string FlightNumber { get; set; }
        public string DestinationCode { get; set;}
        public string DepartureCode { get; set;}
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set;}
    }
}