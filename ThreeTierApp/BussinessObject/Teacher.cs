using System;
using System.Collections.Generic;

namespace BussinessObject
{
    public class Teacher : Account
    {
        //Major
        //Education
        //YearOfEducation
        //JoinDate

        public string Major { get; set; }

        public string Education { get; set; }

        public int YearOfEducation { get; set; }
        public DateTime JoinDate { get; set; }

        public override List<WorkItem> Works { get; set; }
        public string Name { get; set; }
    }
}
