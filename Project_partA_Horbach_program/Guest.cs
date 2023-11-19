using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partA_Horbach_program
{
    public class Guest : IPerson
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public string FirstName { get { throw new NotImplementedException(); } set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Id => throw new NotImplementedException();

        public Guest(string name, string contactNumber, DateTime birthdate)
        {
            throw new NotImplementedException();
        }

        public string Tostring()
        {
            throw new NotImplementedException();
        }

        public string GetFullName()
        {
            throw new NotImplementedException();
        }

        public int GetAge()
        {
            throw new NotImplementedException();
        }

        public string GetContactNumber()
        {
            throw new NotImplementedException();
        }
    }
}