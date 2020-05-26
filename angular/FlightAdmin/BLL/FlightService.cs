using System;
using System.Threading.Tasks;
using FlightAdmin.DAL;
using FlightAdmin.Entities;

namespace FlightAdmin.BLL
{
    public class FlightService : IFlightService
    {
        private IFlightRepository repository;

        public FlightService()
        {
            //TODO: Inject repository via constructor using Autofac
            repository = new FlightsRepository();
        }

        public async Task CreateAsync(Flight entity)
        {
            try
            {
                await repository.CreateAsync(entity);
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}