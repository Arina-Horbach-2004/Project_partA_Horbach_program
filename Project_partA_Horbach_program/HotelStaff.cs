using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partA_Horbach_program
{
    public class HotelStaff : IPerson
    {
        public string Name { get; set; } = string.Empty;
        public string ContactNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public StaffPosition StaffPosition { get; set; }

        public HotelStaff(string name, string contactNumber, DateTime birthdate, StaffPosition position)
        {
            throw new NotImplementedException();
        }
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Id => throw new NotImplementedException();

        public string Tostring()
        {
            throw new NotImplementedException();
        }

        public string GetFullName()
        {
            throw new NotImplementedException();
        }
        public string GetContactNumber()
        {
            throw new NotImplementedException();
        }
        public int GetAge()
        {
            throw new NotImplementedException();
        }
    }
}
