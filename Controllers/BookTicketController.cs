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
    public class BookTicketController : ControllerBase
    {
        private readonly IReservationRepo r;
        public BookTicketController(IReservationRepo r)
        {
            this.r = r;
        }
        private AirLineDbContext d = new AirLineDbContext();

        [HttpPost]
        public string BookTicket(string FlightID, DateTime JourneyDate, string PassengerName, long ContactNo, string Email, int NoOftickets)
        {
            return r.BookTicket(FlightID, JourneyDate, PassengerName, ContactNo, Email, NoOftickets);
        }

    }
}
