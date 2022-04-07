using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;



namespace AirLineReservationServices.Repositories
{
    public class FlightRepo : IFlightRepo
    {
        private readonly AirLineDbContext d =  new AirLineDbContext();


        public List<Flight> AddFlight(string FlightID, DateTime LaunchDate, string Origin, string Destination, string DeptTime, string ArrivalTime, int NoOfSeats, float Fare)
        {
            Flight flight = new Flight(FlightID, LaunchDate, Origin, Destination, DeptTime, ArrivalTime, NoOfSeats, Fare);

            d.Flights.Add(flight);
            d.SaveChanges();

            return d.Flights.ToList();
        }



        public List<Flight> RemoveFlight(string FlightID)
        {
            var flight = d.Flights.Where(x => x.FlightID == FlightID).SingleOrDefault();

            d.Remove(flight);
            d.SaveChanges();

            return d.Flights.ToList();
        }

        public List<Flight> ViewFlight()
        {
            var res = d.Flights.ToList();
            return res;
        }

  
    }
}
