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
        [MinLength(3, ErrorMessage = "min length is 3"), MaxLength(10, ErrorMessage = "Max length is 10")]
        public string Name { get; set; }
        [MinLength(3, ErrorMessage = "min length is 3"), MaxLength(20, ErrorMessage = "Max length is 20")]
        public string Manager { get; set; }
        [RegularExpression("[a-zA-Z]{3,20}", ErrorMessage = "letters only and no more than ")]
        public string location { get; set; }
        public branches branch { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
    }
}
