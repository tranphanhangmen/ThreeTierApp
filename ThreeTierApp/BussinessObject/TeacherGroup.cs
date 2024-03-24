using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    class TeacherGroup
    {
        public int TeacherId { get; set; }
        public int ManagerID { get; set; }
        public DateTime JoinData { get; set; }
        public string GroupName { get; set; }
    }
}
