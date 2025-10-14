using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public enum branches
    {
        Cairo,
        Alexandria,
        Giza,
        Mansoura,
        Aswan,
    }
    public class Department
    {
        [Key]
        public int deptid { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public string location { get; set; }
        public branches branch { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
    }
}
