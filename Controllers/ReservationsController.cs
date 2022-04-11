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
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepo r;
        public ReservationsController(IReservationRepo r)
        {
            this.r = r;
        }
        private AirLineDbContext d = new AirLineDbContext();

        [HttpPost]
        [Route("BookTickets")]
        public string BookTicket(string FlightID, DateTime JourneyDate, string PassengerName, long ContactNo, string Email, int NoOftickets)
        {
            return r.BookTicket(FlightID, JourneyDate, PassengerName, ContactNo, Email, NoOftickets);
        }


        [HttpGet]
        [Route("ViewReservations")]
        public List<Reservation> ViewTicketStatus(string PassengerName)
        {
            return r.ViewTickets(PassengerName);
        }


        [HttpPut]
        [Route("CancelBookedTicket")]
        public Reservation CancelTicket(int TicketNo)
        {
            return r.CancelTicket(TicketNo);
        }

        [HttpGet]
        [Route("GenerateFlightRevenue")]
        public float GetRevenue(string FlightID)
        {
            return r.GenerateRevenue(FlightID);
        }

        [HttpGet]
        [Route("GenerateCGAirLineRevnue")]
        public float RevenueOfCGAirLine()
        {
            return r.TotalRevenueOfAirLine();

        }

        [HttpGet]
        [Route("RevenueOfFlightByDate")]
        public float GetRevenueOfFlightByDate(string FlightID, DateTime RevenueStartDate, DateTime RevenueEndDate)
        {
            return r.GenerateRevenue(FlightID, RevenueStartDate, RevenueEndDate);
        }

        [HttpGet]
        [Route("RevnueCGAirLineByDate")]
        public float RevenueOfCGAirLine(DateTime RevenueStartDate, DateTime RevenueEndDate)
        {
            return r.TotalRevenueOfAirLine(RevenueStartDate, RevenueEndDate);

        }

    }
}
