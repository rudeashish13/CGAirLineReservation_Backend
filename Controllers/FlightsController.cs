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
    public class FlightsController : ControllerBase
    {
        private readonly IFlightRepo f;
        public FlightsController(IFlightRepo f)
        {
            this.f = f;
        }
        //private AirLineDbContext d = new AirLineDbContext();

        [HttpPost]
        [Route("AddFlight")]
        public string AddFlights(Flight flight)
        {


            return f.AddFlight(flight.FlightID, flight.LaunchDate, flight.Origin, flight.Destination,
                flight.DeptTime, flight.ArrivalTime, flight.NoOfSeats, flight.Fare);

        }



        [HttpGet]//("ViewFlights")]
        [Route("ViewFlights")]
        public List<Flight> GetFlights(string Origin, string Destination)
        {
            return f.ViewFlight(Origin, Destination);
        }


        [HttpDelete]
        [Route("RemoveFlight")]
        public List<Flight> RemoveFlights(string FlightID)
        {
            return f.RemoveFlight(FlightID);
        }



        [HttpGet]
        [Route("ViewFlightById")]
        public Flight ViewFlightByID(string FlightID)
        {
            return f.ViewFlight(FlightID);

        }
        
        [HttpPost]
        [Route("EditFlightDetails")]
        public string UpdateFlights(string FlightID,Flight flight)
        {

            using (var d = new AirLineDbContext())
            {


                // Access particular record from a database
                var data = d.Flights.FirstOrDefault(x => x.FlightID == FlightID);

                //if any such record exist update
                if (data != null)
                {
                    data.LaunchDate = flight.LaunchDate;
                    data.Origin = flight.Origin;
                    data.Destination = flight.Destination;
                    data.DeptTime = flight.DeptTime;
                    data.ArrivalTime = flight.ArrivalTime;
                    data.Fare = flight.Fare;
                    data.NoOfSeats = flight.NoOfSeats;
                    d.SaveChanges();


                    return "FLight Updated";
                }
                else
                    return "Flight DOesn't Exist";
            }
        }




    }
}
