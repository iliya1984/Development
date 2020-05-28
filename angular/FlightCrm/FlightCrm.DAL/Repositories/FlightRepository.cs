using System;
using System.Threading.Tasks;
using FlightCrm.DAL.Interfaces;
using FlightCrm.Entities;
using Dapper;
using FlightCrm.DAL.DbEntities;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace FlightCrm.DAL.Repositories
{
    internal class FlightRepository : DapperRepository, IFlightRepository
    {
        public FlightRepository() : base()
        {

        }

        public async Task<Flight> CreateAsync(Flight entity)
        {
            try
            {
                var dbFlight = toDbFlight(entity);

                await ExecuteAsync( async (connection) =>
                {
                     var dbFlights = await connection.QueryAsync<DbFlight>(
                        sql: "usp_InsertFlight", 
                        param: dbFlight,
                        commandType: CommandType.StoredProcedure
                    );

                    dbFlight = dbFlights.FirstOrDefault();
                });

                if(dbFlight == null)
                {
                    return null;
                }

                return toFlight(dbFlight);
            }
            catch (Exception ex)
            {
                //TODO: log error
                return await Task.FromResult<Flight>(null);
            }
        }

        public async Task<List<Flight>> GetAsync(FlightFilter filter)
        {
            try
            {
                List<DbFlight> dbItems = null;
                DbFlightFilter dbFilter = new DbFlightFilter();
                
                await ExecuteAsync( async (connection) =>
                {
                     var dbFlights = await connection.QueryAsync<DbFlight>(
                        sql: "usp_SelectFlights", 
                        param: dbFilter,
                        commandType: CommandType.StoredProcedure
                    );

                    dbItems = dbFlights.ToList();
                });

                if(dbItems == null || false == dbItems.Any())
                {
                    return new List<Flight>();
                }

                return dbItems.Select(dbItem => toFlight(dbItem)).ToList();
            }
            catch (Exception ex)
            {
                //TODO: log error
                return await Task.FromResult<List<Flight>>(new List<Flight>());
            }
        }

        public async Task<Flight> UpdateAsync(Flight entity)
        {
            try
            {
                var dbFlight = toDbFlight(entity);

                await ExecuteAsync( async (connection) =>
                {
                     var dbFlights = await connection.QueryAsync<DbFlight>(
                        sql: "usp_UpdateFlight", 
                        param: dbFlight,
                        commandType: CommandType.StoredProcedure
                    );

                    dbFlight = dbFlights.FirstOrDefault();
                });

                if(dbFlight == null)
                {
                    return null;
                }

                return toFlight(dbFlight);
            }
            catch (Exception ex)
            {
                //TODO: log error
                return await Task.FromResult<Flight>(null);
            }
        }


        private DbFlight toDbFlight(Flight flight)
        {
            var dbFlight = new DbFlight();
            dbFlight.FlightNumber = flight.FlightNumber;
            dbFlight.DepartureCode = flight.DepartureCode;
            dbFlight.DestinationCode = flight.DestinationCode;
            dbFlight.DepartureDate = flight.DepartureDate;
            dbFlight.ReturnDate = flight.ReturnDate;
            dbFlight.Id = flight.Id;

            return dbFlight;
        }

        private Flight toFlight(DbFlight dbFlight)
        {
            var flight = new Flight();
            flight.FlightNumber = dbFlight.FlightNumber;
            flight.DepartureCode = dbFlight.DepartureCode;
            flight.DestinationCode = dbFlight.DestinationCode;
            flight.DepartureDate = dbFlight.DepartureDate;
            flight.ReturnDate = dbFlight.ReturnDate;
            flight.Id = dbFlight.Id;

            return flight;
        }
    }
}