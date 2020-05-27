using FlightCrm.DAL.Interfaces;

namespace FlightCrm.DAL.Repositories
{
    public static class RpositoryFactory
    {
        public static IFlightRepository CreateFlightRepository()
        {
            return new FlightRepository();
        }
    }
}