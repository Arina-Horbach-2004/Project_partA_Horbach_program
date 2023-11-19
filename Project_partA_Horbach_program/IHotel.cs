using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partA_Horbach_program
{
    public interface IHotel
    {
        // Реєстрація посетителя
        public void RegisterGuest(Guest guest);

        // Бронювання номеру
        public void ReserveRoom(Guest guest, Room room);

        // Видалення персоналу
        public void RemoveStaff(HotelStaff staff);

        void CheckIn(Guest guest, Room room, HotelStaff checkedInBy);

        // Виселення посетителя
        public void CheckOut(Guest guest);

        // Отримати список сотрудників
        List<HotelStaff> GetStaffList();

        // Отримати список посетителів
        List<Guest> GetGuestList();

        // Отримати список номерів
        List<Room> GetRoomList();

        public string Tostring();
    }
}