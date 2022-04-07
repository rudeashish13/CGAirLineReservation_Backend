using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;



namespace AirLineReservationServices.Repositories
{
    public interface IFlightRepo
    {
        List<Flight> AddFlight(string FlightID, DateTime LaunchDate, string Origin, string Destination,
            string DeptTime, string ArrivalTime, int NoOfSeats, float Fare);
        List<Flight> RemoveFlight(string FlightID);
        List<Flight> ViewFlight();
    }
}
