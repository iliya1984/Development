using FlightCrm.Entities;

namespace FlightCrm.DAL.Interfaces
{
    public interface IFlightRepository: ICreateRepository<Flight>, IUpdateRepository<Flight>, IGetRepository<Flight, FlightFilter>
    {
         
    }
}