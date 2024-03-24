using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Manager : Account
    {
        public string Position { get; set; }
        public int JoinYear { get; set; }

        public override List<WorkItem> Works { get; set; }
    }
}
