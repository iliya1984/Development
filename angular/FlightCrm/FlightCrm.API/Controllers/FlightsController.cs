using System;
using System.Threading.Tasks;
using System.Web.Http;
using FlightCrm.BLL.Interfaces;
using FlightCrm.BLL.Services;
using FlightCrm.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlightCrm.API.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class FlightsController: ControllerBase
    {
        private IFlightService service;

        public FlightsController()
        {
            //TODO: Inject service via constructor
            service = ServiceFactory.CreateFlightService();
        }

        [HttpPost()]
        [Route("api/flights/new")]
        public async Task<IActionResult> CreateFlightAsync(Flight flight)
        {
            try
            {
                
                var result = await service.CreateAsync(flight);
                if(result == null)
                {
                    return new InternalServerErrorResult();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                return new ExceptionResult(ex, true);
            }
        }

        [HttpPut]
        [Route("api/flights/edit")]
        public async Task<IActionResult> UpdateFlightAsync([FromBody]Flight flight)
        {
            try
            {
                var result = await service.UpdateAsync(flight);
                if(result == null)
                {
                    return new InternalServerErrorResult();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                return new ExceptionResult(ex, true);
            }
        }

        [HttpGet("api/flights/{flightId:int?}")]
        public async Task<IActionResult> GetFlightAsync(int flightId = 0)
        {
            try
            {
                var result = await service.GetAsync(new FlightFilter{ FlightId = flightId });
                if(result == null)
                {
                    return new InternalServerErrorResult();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                return new ExceptionResult(ex, true);
            }
        }
    }
}