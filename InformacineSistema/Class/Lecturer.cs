using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacineSistema
{
    public class Lecturer : IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Group { get; set; }           //SIUO ATVEJU DALYKAS
        public int DalykoID { get; set; }
        public bool isAdmin()
        {
            return false;
        }
        public bool isLecturer()
        {
            return true;
        }
    }
}
