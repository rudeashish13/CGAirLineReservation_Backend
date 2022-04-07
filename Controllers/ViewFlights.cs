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
    public class ViewFlights : ControllerBase
    {

        private readonly IFlightRepo f;

        public ViewFlights(IFlightRepo f)
        {
            this.f = f;
        }

        [HttpGet("ViewFlights")]
        public List<Flight> GetFlights()
        {
            return f.ViewFlight();
        }

        

    }
}
