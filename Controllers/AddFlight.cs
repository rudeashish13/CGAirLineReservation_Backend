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
        [Route("FlightID/LaunceDate/Origin/Destination/DepartureTime/ArrivalTime/NumberOfSeats/Fare")]
        public List<Flight> AddFlights(string FlightID, DateTime LaunchDate, string Origin, string Destination,
            string DeptTime, string ArrivalTime, int NoOfSeats, float Fare)
        {
            

            return f.AddFlight(FlightID, LaunchDate, Origin, Destination, DeptTime, ArrivalTime, NoOfSeats, Fare);
            
        }


    }
}
