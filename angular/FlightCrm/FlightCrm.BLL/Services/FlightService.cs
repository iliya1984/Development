using System.Collections.Generic;
using System.Threading.Tasks;
using FlightCrm.BLL.Interfaces;
using FlightCrm.DAL.Interfaces;
using FlightCrm.Entities;
using FlightCrm.DAL.Repositories;
using System;

namespace FlightCrm.BLL.Services
{
    internal class FlightService : IFlightService
    {
        private IFlightRepository repository;

        public  FlightService()
        {
            //TODO: Change, Inject via constructor
            repository = RpositoryFactory.CreateFlightRepository();
        }
        public async Task<Flight> CreateAsync(Flight entity)
        {
            try
            {
                return await repository.CreateAsync(entity);
            }
            catch(Exception ex)
            {
                //TODO: log error
                return null;
            }
        }

        public async Task<List<Flight>> GetAsync(FlightFilter filter)
        {
             try
            {
                return await repository.GetAsync(filter);
            }
            catch(Exception ex)
            {
                //TODO: log error
                return new List<Flight>();
            }
        }

        public async Task<Flight> UpdateAsync(Flight entity)
        {
            try
            {
                return await repository.UpdateAsync(entity);
            }
            catch(Exception ex)
            {
                //TODO: log error
                return null;
            }
        }
    }
}