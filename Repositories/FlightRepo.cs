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

        //Adding a Flight to the database
        public string AddFlight(string FlightID, DateTime LaunchDate, string Origin, string Destination, string DeptTime, string ArrivalTime, int NoOfSeats, float Fare)
        {
            //check if the FlightID already exists
            var results = d.Flights.Where(x => x.FlightID == FlightID).ToList();
            if (results.Count > 0)
            {
                return "Flight Already exists";
            }
            else
            {
                Flight flight = new Flight();

                flight.FlightID = FlightID;
                flight.LaunchDate = DateTime.Today;
                flight.Origin = Origin;
                flight.Destination = Destination;
                flight.DeptTime = DeptTime;
                flight.ArrivalTime = ArrivalTime;
                flight.NoOfSeats = NoOfSeats;
                flight.Fare = Fare;

                d.Flights.Add(flight);
                d.SaveChanges();

                return "Flight Added Succcesfully";
            }
        }

        


        // Removing flights from the database
        public List<Flight> RemoveFlight(string FlightID)
        {
            var flight = d.Flights.Where(x => x.FlightID == FlightID).SingleOrDefault();

            d.Remove(flight);
            d.SaveChanges();

            return d.Flights.ToList();
        }

        //View Flights by adding SOurce and Destination
        public List<Flight> ViewFlight(string Source,String Destination)
        {
            if (Source != null && Destination != null)
                return d.Flights.Where(x => x.Origin == Source && x.Destination == Destination).ToList();
            else
                return d.Flights.ToList();
        }

        public Flight ViewFlight(string FlightID)
        {
            
            return d.Flights.Where(x => x.FlightID == FlightID).SingleOrDefault();
        }

        
    }
}
