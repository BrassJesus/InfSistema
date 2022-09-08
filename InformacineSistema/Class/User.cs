using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacineSistema
{
    public interface IUser
    {
        int ID { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Group { get; set; }
        bool isAdmin();
        bool isLecturer();
    }
}
