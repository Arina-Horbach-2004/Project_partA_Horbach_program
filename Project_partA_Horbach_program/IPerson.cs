using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_partA_Horbach_program
{
    public interface IPerson
    {
        int Id { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        public string Tostring();
    }
}