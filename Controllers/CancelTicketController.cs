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
    public class CancelTicketController : ControllerBase
    {
        private readonly IReservationRepo r;
        public CancelTicketController(IReservationRepo r)
        {
            this.r = r;
        }
        private AirLineDbContext d = new AirLineDbContext();

        [HttpPut]
        [Route("{TicketNo}")]
        public Reservation CancelTicket(int TicketNo)
        {
            return r.CancelTicket(TicketNo);
        }
    }
}
