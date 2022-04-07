using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;
using AirLineReservationServices.Repositories;

namespace AirLineReservationServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveFlight : ControllerBase
    {
        private readonly IFlightRepo f;
        public RemoveFlight(IFlightRepo f)
        {
            this.f = f;
        }

        [HttpDelete]
        [Route("FlightID")]
        public List<Flight> RemoveFlights(string FlightID)
        {
            return f.RemoveFlight(FlightID);
        }
    }
}
