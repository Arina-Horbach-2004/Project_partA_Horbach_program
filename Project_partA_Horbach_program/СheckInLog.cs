using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partA_Horbach_program
{
    public class CheckInLog
    {
        // Властивість для зберігання часу заселення
        public DateTime CheckInTime { get; }

        // Властивість для зберігання інформації про гостя
        public Guest Guest { get; }

        // Властивість для зберігання інформації про номер
        public Room Room { get; }

        // Властивість для зберігання інформації про персонал готелю, який провів заселення
        public HotelStaff CheckedInBy { get; }

        public CheckInLog(DateTime checkInTime, Guest guest, Room room, HotelStaff checkedInBy)
        {
            throw new NotImplementedException();
        }
    }
}