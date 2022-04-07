using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;

namespace AirLineReservationServices.Repositories
{
    public interface IReservationRepo
    {
        string BookTicket(string FlightID, DateTime JourneyDate, string PassengerName, int ContactNo, string Email, int NoOftickets);
        Reservation CancelTicket(int TicketNo);
        Reservation ViewTicketStatus(int TicketNo);
    }
}
