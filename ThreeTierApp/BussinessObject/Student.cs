using System.Collections.Generic;

namespace BussinessObject
{
    public class Student : Account
    {
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }

        public override List<WorkItem> Works { get; set; }
    }
}
