using FlightCrm.BLL.Interfaces;

namespace FlightCrm.BLL.Services
{
    public static class ServiceFactory
    {
        public static IFlightService CreateFlightService()
        {
            return new FlightService();
        }
    }
}