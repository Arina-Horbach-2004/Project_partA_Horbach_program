using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project_partA_Horbach_program;
using System;

namespace HotelTests
{
    [TestClass]
    public class HotelTests
    {
        // Перевірка, чи коректно виписується гість при виклику методу CheckOut
        [TestMethod]
        public void CheckOut_ValidGuest_ShouldCheckOutGuest()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest = new Project_partA_Horbach_program.Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));
            hotel.RegisterGuest(guest); // Реєстрація гостя в готелі

            // Act
            hotel.CheckOut(guest);

            // Assert
            Assert.IsFalse(hotel.GetGuestList().Contains(guest)); // Перевірка, що гостя виписано
        }

        // Перевірка, чи виникає виняток для невірного гостя при виклику методу CheckOut
        [TestMethod]
        public void CheckOut_InvalidGuest_ShouldThrowException()
        {
            // Arrange
            var hotel = new Hotel("Country", "City");
            var invalidGuest = new Guest("Invalid Guest", "48538353801", new DateTime(1995, 1, 1));

            // Act & Assert
            Assert.ThrowsException<Exception>(() => hotel.CheckOut(invalidGuest));
        }

        // Перевірка, що метод GetGuestList() повертає порожній список, якщо немає зареєстрованих гостей
        [TestMethod]
        public void GetGuestList_NoGuestsRegistered_ShouldReturnEmptyList()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");

            // Act
            var guestList = hotel.GetGuestList();

            // Assert
            Assert.IsNotNull(guestList);
            Assert.AreEqual(0, guestList.Count);

        }

        // Перевірка, що метод GetGuestList() повертає список всіх зареєстрованих гостей
        [TestMethod]
        public void GetGuestList_ReturnsListOfRegisteredGuests()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest1 = new Project_partA_Horbach_program.Guest("Ferit Korhan", "123456789", new DateTime(1990, 1, 1));
            var guest2 = new Project_partA_Horbach_program.Guest("Seyran Korhan", "987654321", new DateTime(1995, 1, 1));
            hotel.RegisterGuest(guest1);
            hotel.RegisterGuest(guest2);

            // Act
            var guestList = hotel.GetGuestList();

            // Assert
            Assert.IsNotNull(guestList);
            Assert.AreEqual(2, guestList.Count);
            CollectionAssert.Contains(guestList, guest1);
            CollectionAssert.Contains(guestList, guest2);
        }

        // Перевірка, що метод GetGuestList() повертає порожній список після виселення всіх гостей
        [TestMethod]
        public void GetGuestList_ReturnsEmptyListAfterCheckingOutAllGuests()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest = new Project_partA_Horbach_program.Guest("Ferit Korhan", "4538353801", new DateTime(1990, 1, 1));
            hotel.RegisterGuest(guest);
            hotel.CheckOut(guest);

            // Act
            var guestList = hotel.GetGuestList();

            // Assert
            Assert.IsNotNull(guestList);
            Assert.AreEqual(0, guestList.Count);
        }

        // Перевірка, що метод GetGuestList() правильно повертає список гостей після декількох операцій
        [TestMethod]
        public void GetGuestList_ReturnsListOfRegisteredGuestsAfterSeveralOperations()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest1 = new Project_partA_Horbach_program.Guest("Ferit Korhan", "4538353801", new DateTime(1990, 1, 1));
            var guest2 = new Project_partA_Horbach_program.Guest("Seyran Korhan", "48536353802", new DateTime(1995, 1, 1));
            hotel.RegisterGuest(guest1);
            hotel.RegisterGuest(guest2);
            hotel.CheckOut(guest1);

            // Act
            var guestList = hotel.GetGuestList();

            // Assert
            Assert.IsNotNull(guestList);
            Assert.AreEqual(1, guestList.Count);
            CollectionAssert.Contains(guestList, guest2);
            CollectionAssert.DoesNotContain(guestList, guest1);
        }

        // Перевірка, що метод GetRoomList() повертає порожній список, якщо немає доступних номерів
        [TestMethod]
        public void GetRoomList_NoRoomsAvailable_ShouldReturnEmptyList()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");

            // Act
            var roomList = hotel.GetRoomList();

            // Assert
            Assert.IsNotNull(roomList);
            Assert.AreEqual(0, roomList.Count);
        }

        // Перевірка, що метод GetRoomList() повертає список всіх доступних номерів
        [TestMethod]
        public void GetRoomList_ReturnsListOfAvailableRooms()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var room1 = new Project_partA_Horbach_program.Room(101, 100, RoomType.Single);
            var room2 = new Project_partA_Horbach_program.Room(102, 150, RoomType.Double);
            hotel.Rooms.Add(room1);
            hotel.Rooms.Add(room2);

            // Act
            var roomList = hotel.GetRoomList();

            // Assert
            Assert.IsNotNull(roomList);
            Assert.AreEqual(2, roomList.Count);
            CollectionAssert.Contains(roomList, room1);
            CollectionAssert.Contains(roomList, room2);

        }

        // Перевірка, що метод GetRoomList() повертає порожній список після бронювання всіх номерів
        [TestMethod]
        public void GetRoomList_ReturnsEmptyListAfterReservingAllRooms()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest = new Project_partA_Horbach_program.Guest("Ferit Korhan", "4538353801", new DateTime(1990, 1, 1));
            var room1 = new Project_partA_Horbach_program.Room(101, 100, RoomType.Single);
            var room2 = new Project_partA_Horbach_program.Room(102, 150, RoomType.Double);
            hotel.Rooms.Add(room1);
            hotel.Rooms.Add(room2);
            hotel.ReserveRoom(guest, room1);
            hotel.ReserveRoom(guest, room2);

            // Act
            var roomList = hotel.GetRoomList();

            // Assert
            Assert.IsNotNull(roomList);
            Assert.AreEqual(0, roomList.Count);

        }

        // Перевірка, що метод GetRoomList() повертає список доступних номерів після виселення гостя
        [TestMethod]
        public void GetRoomList_ReturnsListOfAvailableRoomsAfterCheckOut()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest = new Project_partA_Horbach_program.Guest("Ferit Korhan", "4538353801", new DateTime(1990, 1, 1));
            var room1 = new Project_partA_Horbach_program.Room(101, 100, RoomType.Single);
            var room2 = new Project_partA_Horbach_program.Room(102, 150, RoomType.Double);
            hotel.Rooms.Add(room1);
            hotel.Rooms.Add(room2);
            hotel.ReserveRoom(guest, room1);
            hotel.ReserveRoom(guest, room2);
            hotel.CheckOut(guest);

            // Act
            var roomList = hotel.GetRoomList();

            // Assert
            Assert.IsNotNull(roomList);
            Assert.AreEqual(2, roomList.Count);
            CollectionAssert.Contains(roomList, room1);
            CollectionAssert.Contains(roomList, room2);
        }

        // Перевірка, що метод GetStaffList() повертає порожній список, якщо немає доступного персоналу
        [TestMethod]
        public void GetStaffList_NoStaffAvailable_ShouldReturnEmptyList()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");

            // Act
            var staffList = hotel.GetStaffList();

            // Assert
            Assert.IsNotNull(staffList);
            Assert.AreEqual(0, staffList.Count);
        }

        // Перевірка, що метод GetStaffList() повертає список всього доступного персоналу
        [TestMethod]
        public void GetStaffList_ReturnsListOfAvailableStaff()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var staff1 = new Project_partA_Horbach_program.HotelStaff("Mikhael Dolan", "Staff Position", new DateTime(1990, 1, 1), StaffPosition.Staff);
            var staff2 = new Project_partA_Horbach_program.HotelStaff("Lara Doe", "Manager", new DateTime(1995, 1, 1), StaffPosition.Manager);
            hotel.Staff.Add(staff1);
            hotel.Staff.Add(staff2);

            // Act
            var staffList = hotel.GetStaffList();

            // Assert
            Assert.IsNotNull(staffList);
            Assert.AreEqual(2, staffList.Count);
            CollectionAssert.Contains(staffList, staff1);
            CollectionAssert.Contains(staffList, staff2);
        }

        // Перевірка, що метод GetStaffList() повертає порожній список після видалення персоналу
        [TestMethod]
        public void GetStaffList_ReturnsEmptyListAfterRemovingStaff()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var staff = new Project_partA_Horbach_program.HotelStaff("Mikhael Dolan", "Staff Position", new DateTime(1990, 1, 1), StaffPosition.Staff);
            hotel.Staff.Add(staff);
            hotel.RemoveStaff(staff);

            // Act
            var staffList = hotel.GetStaffList();

            // Assert
            Assert.IsNotNull(staffList);
            Assert.AreEqual(0, staffList.Count);
        }

        // Перевірка, що метод GetStaffList() повертає список доступного персоналу після різних операцій
        [TestMethod]
        public void GetStaffList_ReturnsListOfAvailableStaffAfterSeveralOperations()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var staff1 = new Project_partA_Horbach_program.HotelStaff("Mikhael Dolan", "Staff Position", new DateTime(1990, 1, 1), StaffPosition.Staff);
            var staff2 = new Project_partA_Horbach_program.HotelStaff("Lara Doe", "Manager", new DateTime(1995, 1, 1), StaffPosition.Manager);
            hotel.Staff.Add(staff1);
            hotel.Staff.Add(staff2);
            hotel.RemoveStaff(staff1);

            // Act
            var staffList = hotel.GetStaffList();

            // Assert
            Assert.IsNotNull(staffList);
            Assert.AreEqual(1, staffList.Count);
            CollectionAssert.Contains(staffList, staff2);
            CollectionAssert.DoesNotContain(staffList, staff1);
        }

        // Перевірка, що гість був успішно зареєстрований
        [TestMethod]
        public void RegisterGuest_AddValidGuest_ShouldRegisterGuest()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest = new Project_partA_Horbach_program.Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));

            // Act
            hotel.RegisterGuest(guest);

            // Assert
            Assert.IsTrue(hotel.GetGuestList().Contains(guest));
        }

        // Перевірка, що спроба зареєструвати того ж самого гостя двічі призводить до винятку
        [TestMethod]
        public void RegisterGuest_AddDuplicateGuest_ShouldThrowException()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest = new Project_partA_Horbach_program.Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));
            hotel.RegisterGuest(guest);

            // Act & Assert
            Assert.ThrowsException<Exception>(() => hotel.RegisterGuest(guest));
        }

        // Перевірка, що номер був успішно заброньований
        [TestMethod]
        public void ReserveRoom_ValidReservation_ShouldReserveRoom()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest = new Project_partA_Horbach_program.Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));
            var room = new Project_partA_Horbach_program.Room(101, 100, RoomType.Single);

            // Act
            hotel.ReserveRoom(guest, room);

            // Assert
            Assert.IsTrue(room.IsOccupied);
        }

        // Перевірка, що спроба забронювати той же номер іншим гостем призводить до винятку
        [TestMethod]
        public void ReserveRoom_ReserveOccupiedRoom_ShouldThrowException()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest1 = new Project_partA_Horbach_program.Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));
            var guest2 = new Project_partA_Horbach_program.Guest("Jane Nikman", "48536921538", new DateTime(1995, 1, 1));
            var room = new Project_partA_Horbach_program.Room(101, 100, RoomType.Single);
            hotel.ReserveRoom(guest1, room);

            // Act & Assert
            Assert.ThrowsException<Exception>(() => hotel.ReserveRoom(guest2, room));
        }

        // Перевірка, що гість успішно заселений в номер
        [TestMethod]
        public void CheckIn_ValidCheckIn_ShouldCheckInGuest()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest = new Project_partA_Horbach_program.Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));
            var room = new Project_partA_Horbach_program.Room(101, 100, RoomType.Single);
            var staff = new Project_partA_Horbach_program.HotelStaff("Staff Member", "Staff Position", new DateTime(1990, 1, 1), StaffPosition.Receptionist);

            // Act
            hotel.CheckIn(guest, room, staff);

            // Assert
            Assert.IsTrue(room.IsOccupied);
        }

        // Перевірка, що спроба заселити гостя в незареєстрований номер призводить до винятку
        [TestMethod]
        public void CheckIn_CheckInInvalidRoom_ShouldThrowException()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest = new Project_partA_Horbach_program.Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));
            var invalidRoom = new Project_partA_Horbach_program.Room(101, 100, RoomType.Single); // Номер не зареєстрований в готелі
            var staff = new Project_partA_Horbach_program.HotelStaff("Staff Member", "Staff Position", new DateTime(1990, 1, 1), StaffPosition.Receptionist);

            // Act & Assert
            Assert.ThrowsException<Exception>(() => hotel.CheckIn(guest, invalidRoom, staff));
        }

        // Перевірка, що спроба заселити гостя неправильним персоналом призводить до винятку
        [TestMethod]
        public void CheckIn_InvalidStaffPosition_ShouldThrowException()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest = new Project_partA_Horbach_program.Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));
            var room = new Project_partA_Horbach_program.Room(101, 100, RoomType.Single);
            var invalidStaff = new Project_partA_Horbach_program.HotelStaff("Staff Member", "Staff Position", new DateTime(1990, 1, 1), StaffPosition.Administrator);
            // Персонал з неправильною посадою для рецепції

            // Act & Assert
            Assert.ThrowsException<Exception>(() => hotel.CheckIn(guest, room, invalidStaff));
        }

        // Перевірка, що персонал успішно видалено
        [TestMethod]
        public void RemoveStaff_ValidRemoval_ShouldRemoveStaff()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var staff = new Project_partA_Horbach_program.HotelStaff("Staff Member", "Staff Position", new DateTime(1990, 1, 1), StaffPosition.Receptionist);
            hotel.Staff.Add(staff); // Додаємо персонал

            // Act
            hotel.RemoveStaff(staff);

            // Assert
            Assert.IsFalse(hotel.GetStaffList().Contains(staff));
        }

        // Перевірка, що спроба видалити неправильний персонал призводить до винятку
        [TestMethod]
        public void RemoveStaff_InvalidRemoval_ShouldThrowException()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var staff = new Project_partA_Horbach_program.HotelStaff("Staff Member", "Staff Position", new DateTime(1990, 1, 1), StaffPosition.Administrator);
            // Персонал з неправильною посадою для видалення

            // Act & Assert
            Assert.ThrowsException<Exception>(() => hotel.RemoveStaff(staff));
        }

        // Перевірка, що спроба видалити персонал з порожнього списку призводить до винятку
        [TestMethod]
        public void RemoveStaff_EmptyStaffList_ShouldThrowException()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var staff = new Project_partA_Horbach_program.HotelStaff("Staff Member", "Staff Position", new DateTime(1990, 1, 1), StaffPosition.Receptionist);
            // Персонал, якого немає в готелі

            // Act & Assert
            Assert.ThrowsException<Exception>(() => hotel.RemoveStaff(staff));
        }

        //Перевіряє, чи повертає метод ToString() коректну інформацію про готель, включаючи країну, місто та інформацію про зареєстрованих гостей.
        [TestMethod]
        public void ToString_ReturnsCorrectString()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");
            var guest1 = new Project_partA_Horbach_program.Guest("Ferit Korhan", "123456789", new DateTime(1990, 1, 1));
            var guest2 = new Project_partA_Horbach_program.Guest("Seyran Korhan", "987654321", new DateTime(1995, 1, 1));
            hotel.RegisterGuest(guest1);
            hotel.RegisterGuest(guest2);

            // Act
            var hotelInfo = hotel.ToString();

            // Assert
            Assert.IsNotNull(hotelInfo);
            Assert.IsTrue(hotelInfo.Contains("Country"));
            Assert.IsTrue(hotelInfo.Contains("City"));
            Assert.IsTrue(hotelInfo.Contains("Ferit Korhan"));
            Assert.IsTrue(hotelInfo.Contains("Seyran Korhan"));
        }

        //Перевіряє, чи обробляє метод ToString() вірно випадок порожнього готелю, повертаючи коректну інформацію.
        [TestMethod]
        public void ToString_EmptyHotel_ShouldReturnCorrectString()
        {
            // Arrange
            var hotel = new Project_partA_Horbach_program.Hotel("Country", "City");

            // Act
            var hotelInfo = hotel.ToString();

            // Assert
            Assert.IsNotNull(hotelInfo);
            Assert.IsTrue(hotelInfo.Contains("Country"));
            Assert.IsTrue(hotelInfo.Contains("City"));
            Assert.IsFalse(hotelInfo.Contains("Guests:"));
            Assert.IsFalse(hotelInfo.Contains("Rooms:"));
            Assert.IsFalse(hotelInfo.Contains("Staff:"));
        }
    }
}
