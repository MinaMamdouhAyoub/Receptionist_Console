using System;
using System.Collections.Generic;
using System.Linq;

namespace Receptionist
{
    class Program
    {
        static void Main(string[] args)
        {
            Room.reservations.Add(new Reservation() //Dummy reservations for testing
            {
                ArrivalDate = DateTime.Now.Date.AddDays(-15),
                DepartureDate = DateTime.Now.Date.AddDays(-10),
                RoomData = new Room() { RoomNumber = Availablerooms.A102 },
                GuestData = new Guest() { Name = "Laszlo", PhoneNumber = "034445", NoOfPartners = 6 }
            });
            Room.reservations.Add(new Reservation()
            {
                ArrivalDate = DateTime.Now.Date.AddDays(-8),
                DepartureDate = DateTime.Now.Date.AddDays(-6),
                RoomData = new Room() { RoomNumber = Availablerooms.A101 },
                GuestData = new Guest() { Name = "Gabor", PhoneNumber = "203040", NoOfPartners = 8 }
            });
            Room.reservations.Add(new Reservation()
            {
                ArrivalDate = DateTime.Now.Date.AddDays(-4),
                DepartureDate = DateTime.Now.Date.AddDays(-2),
                RoomData = new Room() { RoomNumber = Availablerooms.A103 },
                GuestData = new Guest() { Name = "Zoltan", PhoneNumber = "405060", NoOfPartners = 2 }
            });
            Console.WriteLine("================================");
            Console.WriteLine("Welcome To Hotel Management System");
            while (true)
            {
                Console.WriteLine("Press 'R' for New Reservation OR 'C' for Check room availability OR 'P' for Reservation Price OR 'S' for Showing List of Reservations");
                string read = Console.ReadLine().ToLower();
                if (read == "r")
                    Guest.Reserve();

                else if (read == "c")
                {
                    Console.WriteLine("Please Enter Expected Date of Arrival \nEnter The Date in Format MM/DD/YYYY");
                    DateTime dArrival = new DateTime();
                    DateTime.TryParse(Console.ReadLine(), out dArrival);
                    Room.CheckAvailability(dArrival);
                }
                else if (read == "p")
                {
                    Console.WriteLine("please enter The Reservation name \nThe Reservation name should have first upercase letter");
                    string requestedName = Console.ReadLine();
                    Reservation.CalcPriceWithName(requestedName);
                }
                else if (read == "s")
                {
                    foreach (var item in Room.reservations)
                    {
                        Console.WriteLine("-------------------------------------------------------------------");

                        Console.Write($"Room Number: {item.RoomData.RoomNumber}");
                        Console.Write(" || ");
                        Console.Write($"Reservation Name:{item.GuestData.Name} || Phone No:{item.GuestData.PhoneNumber} " +
                            $" || Total Number of guests {item.GuestData.NoOfPartners} ");
                        Console.Write(" || ");
                        Console.Write($"The price: {item.CalcPrice()} Euro || ");
                        Console.Write($"Check-in Date: {item.ArrivalDate} || ");
                        Console.Write($"Check-out Date: {item.DepartureDate}");
                        Console.Write(" ||\n");
                    }
                }
                else
                    Console.WriteLine("Please Enter a valid Option");
            }
        }
    }    
}
