using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class TestOOP
    {
        public void test()
        {
            var manager = new Manager();
            manager.Works = new List<WorkItem> { new ManageTeacher { Name = "Manage Teacher", Teachers = new List<Teacher> { new Teacher { NickName = "Teacher 1" } } } };

            var teacher = new Teacher();
            teacher.Works = new List<WorkItem> { new MangeStudent { Name = "Manage Student", Students = new List<Student> { new Student { NickName = "Student 1", FatherName = "Father 1" } } } };
        }
    }
}
