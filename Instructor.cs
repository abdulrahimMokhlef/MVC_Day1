using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Image{ get; set; }
        public DateOnly HiringDate { get; set; }
        public string Address { get; set; }
        public int DeptId { get; set; }
        [ForeignKey(nameof(DeptId))]
        public Department Department { get; set; }
        public ICollection<InstructorCourse> InstructorCourses = new HashSet<InstructorCourse>();


    }
}
