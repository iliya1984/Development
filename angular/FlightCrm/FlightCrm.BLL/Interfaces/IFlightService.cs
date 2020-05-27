using FlightCrm.Entities;

namespace FlightCrm.BLL.Interfaces
{
    public interface IFlightService: ICreateService<Flight>, IUpdateService<Flight>, IGetService<Flight, FlightFilter>
    {
         
    }
}