using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;


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
        public int DeptId { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public string Location { get; set; }
        public branches Branch { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
    }
}
