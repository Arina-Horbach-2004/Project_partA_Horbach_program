using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partA_Horbach_program
{
    public class Room
    {
        // Властивість для номеру номера
        public int RoomNumber { get; set; }

        // Властивість для типу номера 
        public RoomType Type { get; set; }

        // Властивість, що вказує, чи зайнятий номер
        public bool IsOccupied { get; set; }

        // Властивість для розцінки за номер
        public double Rate { get; set; }

        public Room(int roomNumber, double rate, RoomType type)
        {
            throw new NotImplementedException();
        }

        // Метод для заселення гостя в номер
        public void CheckIn(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
