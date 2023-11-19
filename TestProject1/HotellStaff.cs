using Project_partA_Horbach_program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class HotellStaffTest
    {

        //Перевіряє, чи коректно встановлені значення полів Name, ContactNumber, BirthDate і StaffPosition при створенні об'єкта гостя.
        [TestMethod]
        public void GuestInitialization_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var name = "Admin";
            var contactNumber = "48538353802";
            var birthDate = new DateTime(1990, 1, 1);
            var staffpossition = StaffPosition.Administrator;

            // Act
            var staff = new HotelStaff(name, contactNumber, birthDate, staffpossition);

            // Assert
            Assert.AreEqual(name, staff.Name);
            Assert.AreEqual(contactNumber, staff.ContactNumber);
            Assert.AreEqual(birthDate, staff.BirthDate);
            Assert.AreEqual(staffpossition, staff.StaffPosition);
        }

        //Перевіряє, чи властивість StaffPosition встановлюється правильно при створенні об'єкта класу HotelStaff.
        [TestMethod]
        public void StaffPosition_SetPosition_ShouldSetStaffPosition()
        {
            // Arrange
            var staff = new HotelStaff("Admin", "48536354802", new DateTime(1990, 1, 1), StaffPosition.Administrator);

            // Act
            var position = staff.StaffPosition;

            // Assert
            Assert.AreEqual(StaffPosition.Administrator, position);
        }

        //Перевіряє, чи контактний номер встановлюється правильно для об'єкта класу HotelStaff.
        [TestMethod]
        public void ContactNumber_ValidFormat_ShouldSetContactNumber()
        {
            // Arrange
            var staff = new HotelStaff("Admin", "48538353802", new DateTime(1990, 1, 1), StaffPosition.Administrator);

            // Act
            var contactNumber = staff.GetContactNumber();

            // Assert
            Assert.AreEqual("48538353802", contactNumber);
        }

        //Перевіряє, чи метод GetFullName класу HotelStaff повертає коректне повне ім'я персоналу
        [TestMethod]
        public void GetFullName_ShouldReturnCorrectFullName()
        {
            // Arrange
            var staff = new HotelStaff("Admin", "48538353802", new DateTime(1990, 1, 1), StaffPosition.Administrator);

            // Act
            var fullName = staff.GetFullName();

            // Assert
            Assert.AreEqual("Admin", fullName);
        }

        [TestMethod]
        public void GetAge_ShouldReturnCorrectAge()
        {
            // Arrange
            var birthDate = new DateTime(1990, 1, 1);
            var staff = new HotelStaff("Admin", "48538353802", new DateTime(1990, 1, 1), StaffPosition.Administrator);

            // Act
            var age = staff.GetAge();

            // Assert
            Assert.AreEqual(DateTime.Now.Year - birthDate.Year, age);
        }

        //Перевіряє, чи метод ToString персоналу повертає коректну інформацію
        [TestMethod]
        public void ToString_ShouldReturnCorrectInformation()
        {
            // Arrange
            var staff = new HotelStaff("Admin", "48538353802", new DateTime(1990, 1, 1), StaffPosition.Administrator);


            // Act
            var staffInfo = staff.ToString();

            // Assert
            Assert.IsNotNull(staffInfo);
            Assert.IsTrue(staffInfo.Contains("Admin"));
            Assert.IsTrue(staffInfo.Contains("48538353801"));
            Assert.IsTrue(staffInfo.Contains("1990-01-01"));
            Assert.IsTrue(staffInfo.Contains("Administrator"));
        }
    }
}
