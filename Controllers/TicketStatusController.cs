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
    public class TicketStatusController : ControllerBase
    {
        private readonly IReservationRepo r;
        public TicketStatusController(IReservationRepo r)
        {
            this.r = r;
        }

        [HttpGet]
        [Route("TicketNo")]
        public Reservation ViewTicketStatus(int TicketNo)
        {
            return r.ViewTicketStatus(TicketNo);
        }
    }
}
