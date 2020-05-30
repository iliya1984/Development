using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightCrm.DAL.DbEntities.Mongo;
using FlightCrm.DAL.Interfaces;
using FlightCrm.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlightCrm.DAL.Repositories
{
    public class MongoFlightRepository : MongoRepository, IFlightRepository
    {
        public MongoFlightRepository()
        {
        }

        public Task<Flight> CreateAsync(Flight entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Flight>> GetAsync(FlightFilter filter)
        {
            try
            {
                List<Flight> flights = new List<Flight>();
                var collection = Database.GetCollection<MongoFlight>("Flights");
            
                var asyncCursor = await collection.FindAsync<MongoFlight>(new BsonDocument());
                var dbFlights = await asyncCursor.ToListAsync();

                if(dbFlights == null || false == dbFlights.Any())
                {
                    return flights;
                }

                dbFlights.ForEach(dbFlight => 
                {
                    try
                    {
                        var flight = toFlight(dbFlight);
                        
                        if(flight != null)
                        {
                            flights.Add(flight);
                        }
                    }
                    catch(Exception ex)
                    {
                        //TODO: log error
                    }
                });

                return flights;
            }
            catch(Exception ex)
            {
                //TODO: handle exception
                return new List<Flight>();
            }
        }

        public Task<Flight> UpdateAsync(Flight entity)
        {
            throw new System.NotImplementedException();
        }

        private Flight toFlight(MongoFlight mongoFlight)
        {
            var flight = new Flight();
            flight.Guid = mongoFlight.id;
            flight.FlightNumber = mongoFlight.flightNumber;
            flight.DepartureCode = mongoFlight.departureCode;
            flight.DestinationCode = mongoFlight.destinationCode;
            flight.DepartureDate = mongoFlight.departureDate;
            flight.ReturnDate = mongoFlight.returnDate;

            return flight;
        }
    }
}