using Microsoft.AspNetCore.Mvc;

namespace FlightAdmin.Controllers
{
    [Route("api/flights")]
    public class FlightsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateFlight(object flight)
        {
            return  null;
        }
    }
}