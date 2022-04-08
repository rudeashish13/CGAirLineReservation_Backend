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
    public class GenerateReport : ControllerBase
    {
        private readonly IReservationRepo r;

        public GenerateReport(IReservationRepo r)
        {
            this.r = r;
        }

        [HttpGet]
        public float GetRevenue(string FlightID)
        {
            return r.GenerateRevenue(FlightID);
        }

        [HttpGet]
        [Route ("RevnueCGAirLine")]
        public float RevenueOfCGAirLine()
        {
            return r.TotalRevenueOfAirLine();
            
        }

        [HttpGet]
        [Route("RevenueOfFlightByDate")]
        public float GetRevenueOfFlightByDate(string FlightID,DateTime RevenueStartDate,DateTime RevenueEndDate)
        {
            return r.GenerateRevenue(FlightID, RevenueStartDate, RevenueEndDate);
        }

        [HttpGet]
        [Route("RevnueCGAirLineByDate")]
        public float RevenueOfCGAirLine(DateTime RevenueStartDate, DateTime RevenueEndDate)
        {
            return r.TotalRevenueOfAirLine(RevenueStartDate,RevenueEndDate);

        }
    }
}
