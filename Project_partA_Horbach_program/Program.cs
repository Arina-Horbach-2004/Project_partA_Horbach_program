using System;
using System.Collections.Generic;

namespace Project_partA_Horbach_program
{
    class Program
    {
        static Hotel? hotel;

        static void Main(string[] args)
        {
            hotel = new Hotel("Україна", "Київ");

            while (true)
            {
                Console.WriteLine("Головне меню:");
                Console.WriteLine("1. Заселити гостя");
                Console.WriteLine("2. Перевірити бронювання");
                Console.WriteLine("3. Виселити гостя");
                Console.WriteLine("4. Додати персонал готелю");
                Console.WriteLine("5. Переглянути інформацію про гостей");
                Console.WriteLine("6. Переглянути інформацію про персонал готелю");
                Console.WriteLine("7. Переглянути інформацію про готель");
                Console.WriteLine("8. Вийти з програми");

                Console.Write("Виберіть опцію (введіть номер): ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Ви обрали опцію 'Заселити гостя'");
                        HandleCheckIn();
                        break;

                    case "2":
                        Console.WriteLine("Ви обрали опцію 'Перевірити бронювання'");
                        HandleReservationCheck();
                        break;

                    case "3":
                        Console.WriteLine("Ви обрали опцію 'Виселити гостя'");
                        HandleCheckOut();
                        break;

                    case "4":
                        Console.WriteLine("Ви обрали опцію 'Додати персонал готелю'");
                        HandleAddStaff();
                        break;

                    case "5":
                        Console.WriteLine("Ви обрали опцію 'Переглянути інформацію про гостей'");
                        PrintGuestInformation();
                        break;

                    case "6":
                        Console.WriteLine("Ви обрали опцію 'Переглянути інформацію про персонал готелю'");
                        PrintStaffInformation();
                        break;

                    case "7":
                        Console.WriteLine("Ви обрали опцію 'Переглянути інформацію про готель'");
                        PrintHotelInformation();
                        break;

                    case "8":
                        Console.WriteLine("Ви обрали опцію 'Вийти з програми'");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Некоректний ввід. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void HandleCheckIn()
        {
            Console.Write("Введіть ім'я гостя: ");
            string name = Console.ReadLine();
            Console.Write("Введіть контактний номер гостя: ");
            string contactNumber = Console.ReadLine();
            Console.Write("Введіть дату народження гостя (у форматі YYYY-MM-DD): ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());

            Guest newGuest = new Guest(name, contactNumber, birthdate);
            hotel.RegisterGuest(newGuest);

            Console.Write("Введіть номер кімнати для бронювання: ");
            int roomNumber = int.Parse(Console.ReadLine());
            Room selectedRoom = hotel.GetRoomList().Find(room => room.RoomNumber == roomNumber);

            hotel.ReserveRoom(newGuest, selectedRoom);

            Console.WriteLine("Гість заселений та номер заброньовано.");
        }

        static void HandleReservationCheck()
        {
            Console.Write("Введіть номер кімнати для перевірки: ");
            int roomNumber = int.Parse(Console.ReadLine());
            Room selectedRoom = hotel.GetRoomList().Find(room => room.RoomNumber == roomNumber);

            if (selectedRoom != null)
            {
                Console.WriteLine($"Номер {selectedRoom.RoomNumber} заброньований: {selectedRoom.IsOccupied}");
            }
            else
            {
                Console.WriteLine("Кімната з вказаним номером не знайдена.");
            }
        }

        static void HandleCheckOut()
        {
            Console.Write("Введіть ім'я гостя для виселення: ");
            string guestName = Console.ReadLine();
            Guest selectedGuest = hotel.GetGuestList().Find(guest => guest.Name == guestName);

            if (selectedGuest != null)
            {
                hotel.CheckOut(selectedGuest);
                Console.WriteLine($"{selectedGuest.Name} виселений з готелю.");
            }
            else
            {
                Console.WriteLine("Гість з вказаним ім'ям не знайдений.");
            }
        }

        static void HandleAddStaff()
        {
            Console.Write("Введіть ім'я персоналу: ");
            string staffName = Console.ReadLine();
            Console.Write("Введіть посаду персоналу: ");
            string staffPosition = Console.ReadLine();

            // Генерація випадкової дати народження
            Random random = new Random();
            DateTime birthDate = new DateTime(random.Next(1970, 1990), random.Next(1, 13), random.Next(1, 29));

            StaffPosition position;
            Enum.TryParse(staffPosition, out position);

            HotelStaff newStaff = new HotelStaff(staffName, staffPosition, birthDate, position);
            hotel.GetStaffList().Add(newStaff);

            Console.WriteLine($"{newStaff.Name} доданий до персоналу готелю.");
        }

        static void PrintGuestInformation()
        {
            List<Guest> guests = hotel.GetGuestList();

            Console.WriteLine("Інформація про гостей:");

            foreach (Guest guest in guests)
            {
                Console.WriteLine($"Ім'я: {guest.Name}, Контактний номер: {guest.ContactNumber}, Дата народження: {guest.BirthDate.ToShortDateString()}");
            }
        }

        static void PrintStaffInformation()
        {
            List<HotelStaff> staffList = hotel.GetStaffList();

            Console.WriteLine("Інформація про персонал готелю:");

            foreach (HotelStaff staff in staffList)
            {
                Console.WriteLine($"Ім'я: {staff.Name}, Посада: {staff.StaffPosition}, Дата народження: {staff.BirthDate.ToShortDateString()}");
            }
        }

        static void PrintHotelInformation()
        {
            Console.WriteLine($"Інформація про готель: Країна - {hotel.Country}, Місто - {hotel.City}");
        }
    }
}
