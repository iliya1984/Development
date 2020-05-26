using System;
using System.Threading.Tasks;
using FlightAdmin.DAL.Entities;
using FlightAdmin.Entities;

namespace FlightAdmin.DAL
{
    public class FlightsRepository : MongoRepository, IFlightRepository
    {
        public FlightsRepository() : base("FlightTestDB"){}

        public async Task CreateAsync(Flight flight)
        {
            try
            {
                var dbFlgiht = new DbFlight();
                dbFlgiht.Id = flight.Id;
                dbFlgiht.FlightNumber = flight.FlightNumber;
                dbFlgiht.DepartureCode = flight.DepartureCode;
                dbFlgiht.DepartureDate = flight.DepartureDate;
                dbFlgiht.DestinationCode = flight.DestinationCode;
                dbFlgiht.ReturnDate = flight.ReturnDate;

                var collection = Database.GetCollection<DbFlight>("Flights");
                await collection.InsertOneAsync(dbFlgiht);
            }
            catch(Exception ex)
            {
                //Log error
            }
        } 
    }
}