using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacineSistema
{
    public class Student : IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public bool isAdmin()
        {
            return false;
        }
        public bool isLecturer()
        {
            return false;
        }
    }
}
