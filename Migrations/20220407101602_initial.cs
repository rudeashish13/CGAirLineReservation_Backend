using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirLineReservationServices.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightID = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: false),
                    LaunchDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Origin = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: true),
                    Destination = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: true),
                    DeptTime = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: true),
                    ArrivalTime = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: true),
                    NoOfSeats = table.Column<int>(type: "int", nullable: false),
                    Fare = table.Column<decimal>(type: "decimal(38,17)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightID);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    TicketNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightID = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: true),
                    DateOfBooking = table.Column<DateTime>(type: "Date", nullable: false),
                    JourneyDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PassengerName = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    ContactNo = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "Varchar(70)", maxLength: 70, nullable: true),
                    NoOfTickets = table.Column<int>(type: "int", nullable: false),
                    TotalFare = table.Column<decimal>(type: "decimal(38,17)", nullable: false),
                    Status = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.TicketNo);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
