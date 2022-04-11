using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLineReservationServices.Entities;

namespace AirLineReservationServices.Repositories
{
    public class ReservationRepo : IReservationRepo
    {
        AirLineDbContext d = new AirLineDbContext();

        //Booking a Ticket, Details of Passenger to get stored in database
        public string BookTicket(string FlightID, DateTime JourneyDate, string PassengerName, long ContactNo, string Email, int NoOftickets)
        {
            var BookingsMade = d.Reservations.Where(x => x.FlightID == FlightID && x.JourneyDate == JourneyDate && x.Status == "Booked").Select(x => x.NoOfTickets).Sum();
            var NoOfSeats = d.Flights.Where(x => x.FlightID == FlightID).Select(x => x.NoOfSeats).ToList()[0];
            //check if seats are availables or not
            if (BookingsMade + NoOftickets > NoOfSeats)
                return "SeatsNotAvailable";
            else
            {
                Reservation reservation = new Reservation();

                reservation.FlightID = FlightID;
                reservation.DateOfBooking = DateTime.Today;
                reservation.JourneyDate = JourneyDate;
                reservation.PassengerName = PassengerName;
                reservation.ContactNo = ContactNo;
                reservation.Email = Email;
                reservation.NoOfTickets = NoOftickets;
                reservation.TotalFare = d.Flights.Where(x => x.FlightID == FlightID).Select(x => x.Fare).ToList()[0] * NoOftickets;
                reservation.Status = "Booked";

                d.Reservations.Add(reservation);
                d.SaveChanges();

                //To print your tickets No:
                var q = reservation.TicketNo;
                
                return $"Booking Succcesful\nYour Ticket No is : {q}";
            }
        }

        //To cancel existing booked reservation/tickets
        public Reservation CancelTicket(int TicketNo)
        {
            //var q = d.Reservations.Where(y => y.TicketNo == TicketNo).Select(c => c.NoOfTickets).SingleOrDefault();
            d.Reservations.Where(x => x.TicketNo == TicketNo)
                            .ToList()
                            .ForEach(f => f.Status = "Cancelled" );

            var q = d.Reservations.Where(c => c.TicketNo == TicketNo).ToList();
            foreach(var i in q)
            {
                i.Status = "Cancelled";
            }


            d.SaveChanges();

            return d.Reservations.Where(x => x.TicketNo == TicketNo).SingleOrDefault();
        }

        
        //Generating Revenue of a Flight
        public float GenerateRevenue(string FlightID)
        {
            var TotalRevenue = d.Reservations.Where(x => x.FlightID == FlightID 
            && x.Status == "Booked").Sum(s => s.TotalFare);

            return TotalRevenue;
                
           
        }

        //Generating Revenue of a Flight in a given time frame
        public float GenerateRevenue(string FlightID, DateTime RevenueStartDate,DateTime RevenueEndDate)
        {
            var t = d.Reservations.Where(x => x.FlightID == FlightID && x.Status == "Booked" && (x.JourneyDate >= RevenueStartDate && x.JourneyDate <= RevenueEndDate)).Sum(s => s.TotalFare);
            return t;
        }

        //Generating Revenue of the Airline
        public float TotalRevenueOfAirLine()
        {
            var t = d.Reservations.Where(x => x.Status == "Booked").Sum(s => s.TotalFare);

            return t;
                
        }

        //Generating Revenue of the Airline in Given Time
        public float TotalRevenueOfAirLine(DateTime RevenueStartDate, DateTime RevenueEndDate)
        {
            var t = d.Reservations.Where(x => x.Status == "Booked" && (x.JourneyDate >= RevenueStartDate && x.JourneyDate <= RevenueEndDate)).Sum(s => s.TotalFare);

            return t;
        }

        //View Tickets/Reservations made by a passenger and the ticket Status
        public List<Reservation> ViewTickets(String PassengerName)
        {
            return d.Reservations.Where(x => x.PassengerName == PassengerName)
                                    .ToList();
        }
    }
}
