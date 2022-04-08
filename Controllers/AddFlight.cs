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
    public class AddFlight : ControllerBase
    {
        private readonly IFlightRepo f;
        public AddFlight(IFlightRepo f)
        {
            this.f = f;
        }
        private AirLineDbContext d = new AirLineDbContext();

        [HttpPost]
        [Route("AddFlight")]
        public string AddFlights(Flight flight)
        {
            

            return f.AddFlight(flight.FlightID, flight.LaunchDate, flight.Origin, flight.Destination,
                flight.DeptTime, flight.ArrivalTime, flight.NoOfSeats, flight.Fare);
            
        }


    }
}
