using System;
using System.Threading.Tasks;
using FlightAdmin.BLL;
using FlightAdmin.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlightAdmin.Controllers
{
    [Route("api/flights")]
    public class FlightsController : ControllerBase
    {
        private IFlightService service;

        public FlightsController()
        {
             //TODO: Inject service via constructor using Autofac
             service = new FlightService();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight(Flight flight)
        {
            try
            {
                await service.CreateAsync(flight);
                return Ok("Create success");
            }
            catch(Exception ex)
            {
                return await Task.FromResult(new ObjectResult(ex));
            }
        }
    }
}