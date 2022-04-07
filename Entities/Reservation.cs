using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirLineReservationServices.Entities
{
    [Table("Reservations")]
    //Reservation Class contains details of the ticket booked by the users.
    public class Reservation
    {
        

        [Key] // TicketNo generated after Booking a flight
        [Column(TypeName = "int")]
        public int TicketNo { get; set; }

        //FlightNo of booked FLight
        [StringLength(10)]
        [Column(TypeName = "Varchar")]
        public string FlightID { get; set; }


        //Date of Booking
        [Column(TypeName = "Date")]
        public DateTime DateOfBooking { get; set; }

        //Date of Journey
        [Column(TypeName = "Date")]
        public DateTime JourneyDate { get; set; }


        //Passenger Name
        [StringLength(50)]
        [Column(TypeName = "Varchar")]
        public string PassengerName { get; set; }

        //phone numbr of passenger
        [Column(TypeName = "bigint")]
        public long ContactNo { get; set; }

        //Email if od passenger
        [StringLength(70)]
        [Column(TypeName = "Varchar")]
        public string Email{ get; set; }

        //No of tickets booked
        [Column(TypeName = "int")]
        public int NoOfTickets { get; set; }

        //Total fare (No. of Tickets Booked*price of a ticket)
        [Column(TypeName ="decimal")]
        public float TotalFare { get; set; }

        //booked/cancelled
        [StringLength(20)]
        [Column(TypeName = "Varchar")]
        public string Status { get; set; }

        




    }
}
