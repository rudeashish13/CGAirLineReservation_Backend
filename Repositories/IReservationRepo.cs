using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;

namespace AirLineReservationServices.Repositories
{
    public interface IReservationRepo
    {
        string BookTicket(string FlightID, DateTime JourneyDate, string PassengerName, long ContactNo, string Email, int NoOftickets);
        Reservation CancelTicket(int TicketNo);
        Reservation ViewTickets(String PassengerName);
        float GenerateRevenue(string FlightID);
        float TotalRevenueOfAirLine();
        float GenerateRevenue(string FlightID, DateTime RevenueStartDate,DateTime RevenueEndDate);
        float TotalRevenueOfAirLine(DateTime RevenueStartDate, DateTime RevenueEndDate);
    }
}
