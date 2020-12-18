using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receptionist
{
    enum Availablerooms
    {
        A101, A102, A103, A104, A105, A106
    }
    class Room : Reservation
    {

        public Availablerooms RoomNumber { get; set; }
        public static List<Reservation> reservations = new List<Reservation>();
        public static void CheckAvailability(DateTime arrival)
        {
            List<Availablerooms> greyList = new List<Availablerooms>();
            foreach (var arrItem in reservations)
            {
                reservations.OrderBy(n => n.RoomData.RoomNumber).ThenBy(n => n.ArrivalDate).GroupBy(n => n.RoomData.RoomNumber).ToList();
                if (!(arrival < arrItem.ArrivalDate || arrival >= arrItem.DepartureDate))
                {
                    greyList.Add(arrItem.RoomData.RoomNumber);
                }
            }
            foreach (Availablerooms val in Enum.GetValues(typeof(Availablerooms)))
            {
                if (!(greyList.Contains(val)))
                    Console.WriteLine(val);
            }
        }
    }
}
