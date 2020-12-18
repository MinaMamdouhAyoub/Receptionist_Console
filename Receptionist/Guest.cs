
using System;
namespace Receptionist
{
    class Guest:Reservation
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int NoOfPartners { get; set; }
        public static void Reserve()
        {
            Console.WriteLine("Plese enter Room Number");
            Console.WriteLine("Enter the room in form of: A10x");
            string roomNo = Console.ReadLine();
            Console.WriteLine("Enter Guests Reservation Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Guest Telephone Number");
            string telephone = Console.ReadLine();
            Console.WriteLine("Enter total number of guets in the reservation");
            int No = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Arrival Date");
            Console.WriteLine("Enter The Date in Format MM/DD/YYYY");
            DateTime ArrivalDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Departure Date ");
            Console.WriteLine("Enter The Date in Format MM/DD/YYYY");
            DateTime depDate = Convert.ToDateTime(Console.ReadLine());
            Receptionist.Availablerooms MyStatus = (Receptionist.Availablerooms)Enum.Parse(typeof(Receptionist.Availablerooms), roomNo);
            Room room = new Room() { RoomNumber = MyStatus };
            Guest g = new Guest() { Name = name, PhoneNumber = telephone, NoOfPartners = No };
            Room.reservations.Add(new Reservation()
            {
                ArrivalDate = ArrivalDate,
                DepartureDate = depDate,
                RoomData = room,
                GuestData = g
            });
            Console.WriteLine("Thanks the booking has been saved.\nTo check price please search using reservation name in 'P' menu.");
        }
    }
}

