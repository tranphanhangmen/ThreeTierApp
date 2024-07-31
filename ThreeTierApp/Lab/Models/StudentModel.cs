using BussinessObject;
using System.ComponentModel.DataAnnotations;

namespace Lab.Models
{
    public class StudentModel : Student
    {
        public string Name { get; set; }
    }
}