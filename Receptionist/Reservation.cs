using System;

namespace Receptionist
{
    class Reservation
    {
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public Room RoomData { get; set; }
        //fixed price per person in room = 100 euro
        /*total price=no of persons*
        fixed price per person in room*no of days*/
        public int price = 100;
        public Guest GuestData { get; set; }
        public int CalcPrice()
        {
            TimeSpan timeSpan = DepartureDate.Date - ArrivalDate.Date;
            int noOfNights = Convert.ToInt32(timeSpan.TotalDays);
            return GuestData.NoOfPartners * price * noOfNights;
        }
        public static void CalcPriceWithName(string n)
        {
            bool flag = false;

            foreach (var item in Room.reservations)
            {
                if (item.GuestData.Name == n)
                {
                    Console.WriteLine($"The price is {item.CalcPrice() } Euro");
                    flag = true;
                    break;
                }
            }
            if (!flag)
                Console.WriteLine("No such reservation name");
        }


    }
}
