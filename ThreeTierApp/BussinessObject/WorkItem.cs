using System.Collections.Generic;

namespace BussinessObject
{
    public class WorkItem
    {
        public string Name { get; set; }
    }

    public class ManageTeacher : WorkItem
    {
        public List<Teacher> Teachers { get; set; }
    }

    public class MangeStudent : WorkItem
    {
        public List<Student> Students { get; set; }
    }

    public class StudySubject : WorkItem
    {
        public List<ClassName> ClassNames { get; set; }
    }
}
