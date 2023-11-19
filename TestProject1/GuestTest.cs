using Project_partA_Horbach_program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class GuestTest
    {
        //Перевіряє, чи коректно встановлені значення полів Name, ContactNumber і BirthDate при створенні об'єкта гостя.
        [TestMethod]
        public void GuestInitialization_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var name = "Ferit Korhan";
            var contactNumber = "48538353801";
            var birthDate = new DateTime(1990, 1, 1);

            // Act
            var guest = new Guest(name, contactNumber, birthDate);

            // Assert
            Assert.AreEqual(name, guest.Name);
            Assert.AreEqual(contactNumber, guest.ContactNumber);
            Assert.AreEqual(birthDate, guest.BirthDate);
        }

        //Перевіряє, чи метод GetFullName повертає коректне повне ім'я гостя.
        [TestMethod]
        public void GetFullName_ShouldReturnCorrectFullName()
        {
            // Arrange
            var guest = new Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));

            // Act
            var fullName = guest.GetFullName();

            // Assert
            Assert.AreEqual("Ferit Korhan", fullName);
        }

        //Перевіряє, чи метод GetAge повертає коректний вік гостя
        [TestMethod]
        public void GetAge_ShouldReturnCorrectAge()
        {
            // Arrange
            var birthDate = new DateTime(1990, 1, 1);
            var guest = new Guest("Ferit Korhan", "48538353801", birthDate);

            // Act
            var age = guest.GetAge();

            // Assert
            Assert.AreEqual(DateTime.Now.Year - birthDate.Year, age);
        }

        //Перевіряє, чи метод ToString гостя повертає коректну інформацію
        [TestMethod]
        public void ToString_ShouldReturnCorrectInformation()
        {
            // Arrange
            var guest = new Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));

            // Act
            var guestInfo = guest.ToString();

            // Assert
            Assert.IsNotNull(guestInfo);
            Assert.IsTrue(guestInfo.Contains("Ferit Korhan"));
            Assert.IsTrue(guestInfo.Contains("48538353801"));
            Assert.IsTrue(guestInfo.Contains("1990-01-01"));
        }

        //Перевіряє, чи метод GetContactNumber повертає очікуваний контактний номер для гостя з коректним форматом.
        [TestMethod]
        public void GetContactNumber_ValidFormat_ShouldReturnContactNumber()
        {
            // Arrange
            var guest = new Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));

            // Act
            var contactNumber = guest.GetContactNumber();

            // Assert
            Assert.AreEqual("48538353801", contactNumber);
        }
    }
}
