using Project_partA_Horbach_program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class RoomTests
    {
        // �������� ����������� ����������� ������������ ������
        [TestMethod]
        public void RoomInitialization_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var roomNumber = 101;
            var rate = 150.0;
            var roomType = RoomType.Single;

            // Act
            var room = new Room(roomNumber, rate, roomType);

            // Assert
            Assert.AreEqual(roomNumber, room.RoomNumber);
            Assert.AreEqual(rate, room.Rate);
            Assert.AreEqual(roomType, room.Type);
            Assert.IsFalse(room.IsOccupied);
        }

        // ��������, �� ��������� ����� � ������ ���������� IsOccupied � true
        [TestMethod]
        public void CheckIn_GuestCheckedIn_ShouldSetIsOccupiedToTrue()
        {
            // Arrange
            var room = new Room(201, 200.0, RoomType.Double);
            var guest = new Guest("Ferit Korhan", "48538353801", new DateTime(1990, 1, 1));

            // Act
            room.CheckIn(guest);

            // Assert
            Assert.IsTrue(room.IsOccupied);
        }

        // ��������, �� ����� CheckIn ������ �������, ���� ���� � ��������
        [TestMethod]
        public void CheckIn_GuestIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var room = new Room(301, 250.0, RoomType.Suite);

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => room.CheckIn(null));
        }

        // ��������, �� ����� CheckIn ������ �������, ���� ������ ��� �������
        [TestMethod]
        public void CheckIn_AlreadyOccupiedRoom_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var room = new Room(401, 300.0, RoomType.Single);
            var guest1 = new Guest("Ferit Korhan", "48538353801", new DateTime(1985, 5, 5));
            var guest2 = new Guest("Bob Smith", "48536353802", new DateTime(1992, 3, 15));

            // Act
            room.CheckIn(guest1);

            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => room.CheckIn(guest2));
        }

        // ��������, �� ��������� ����������� �������� RoomNumber
        [TestMethod]
        public void RoomNumber_SetValue_ShouldSetCorrectValue()
        {
            // Arrange
            var room = new Room(101, 150.0, RoomType.Single);

            // Act
            room.RoomNumber = 201;

            // Assert
            Assert.AreEqual(201, room.RoomNumber);
        }

        // ��������, �� ��������� ����������� �������� Type
        [TestMethod]
        public void Type_SetValue_ShouldSetCorrectValue()
        {
            // Arrange
            var room = new Room(101, 150.0, RoomType.Single);

            // Act
            room.Type = RoomType.Double;

            // Assert
            Assert.AreEqual(RoomType.Double, room.Type);
        }

        // ��������, �� ��������� ����������� �������� IsOccupied
        [TestMethod]
        public void IsOccupied_SetValue_ShouldSetCorrectValue()
        {
            // Arrange
            var room = new Room(101, 150.0, RoomType.Single);

            // Act
            room.IsOccupied = true;

            // Assert
            Assert.IsTrue(room.IsOccupied);
        }

        // ��������, �� ��������� ����������� �������� Rate
        [TestMethod]
        public void Rate_SetValue_ShouldSetCorrectValue()
        {
            // Arrange
            var room = new Room(101, 150.0, RoomType.Single);

            // Act
            room.Rate = 200.0;

            // Assert
            Assert.AreEqual(200.0, room.Rate);
        }
    }
}