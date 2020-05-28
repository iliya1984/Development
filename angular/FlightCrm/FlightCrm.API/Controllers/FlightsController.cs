using System;
using System.Threading.Tasks;
using System.Web.Http;
using FlightCrm.BLL.Interfaces;
using FlightCrm.BLL.Services;
using FlightCrm.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlightCrm.API.Controllers
{
    [ApiController]
    [Route("api/flights")]
    public class FlightsController: ControllerBase
    {
        private IFlightService service;

        public FlightsController()
        {
            //TODO: Inject service via constructor
            service = ServiceFactory.CreateFlightService();
        }

        [HttpPost]
        [Route("api/flights/create")]
        public async Task<IActionResult> CreateFlightAsync([FromBody]Flight flight)
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
        [Route("api/flights/update")]
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

        [HttpGet]
        [Route("api/flights")]
        public async Task<IActionResult> GetFlightAsync([FromBody]FlightFilter filter)
        {
            try
            {
                var result = await service.GetAsync(filter);
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