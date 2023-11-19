using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partA_Horbach_program
{
    public class Hotel : IHotel
    {
        // Властивість для країни, до якої належить готель
        public string? Country { get; set; }

        // Властивість для міста, де розташований готель
        public string? City { get; set; }

        // Список номерів у готелі
        public List<Room> Rooms;

        // Список персоналу готелю
        public List<HotelStaff> Staff;

        // Список гостей готелю
        public List<Guest> guests;

        // Журнал заселення
        public List<CheckInLog> checkInLogs;

        public Hotel(string country, string city)
        {
            throw new NotImplementedException();
        }

        // Метод для реєстрації гостя
        public void RegisterGuest(Guest guest)
        {
            throw new NotImplementedException();
        }

        // Метод для бронювання номеру
        public void ReserveRoom(Guest guest, Room room)
        {
            throw new NotImplementedException();
        }

        // Метод для заселення гостя
        public void CheckIn(Guest guest, Room room, HotelStaff checkedInBy)
        {
            throw new NotImplementedException();
        }

        // Метод для видалення персоналу
        public void RemoveStaff(HotelStaff staff)
        {
            throw new NotImplementedException();
        }

        // Метод для виселення гостя
        public void CheckOut(Guest guest)
        {
            throw new NotImplementedException();
        }

        // Метод для отримання списку гостей
        public List<Guest> GetGuestList()
        {
            throw new NotImplementedException();
        }

        // Метод для отримання списку номерів
        public List<Room> GetRoomList()
        {
            throw new NotImplementedException();
        }

        // Метод для отримання списку персоналу готелю
        public List<HotelStaff> GetStaffList()
        {
            throw new NotImplementedException();
        }

        // Метод для отримання рядка з інформацією про готель
        public string Tostring()
        {
            throw new NotImplementedException();
        }
    }
}