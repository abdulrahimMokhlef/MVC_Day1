using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Course
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Topic{ set; get; }
        public decimal Degree { set; get; }
        public decimal MinDegree { set; get; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<InstructorCourse> InstructorCourses { get; set; } = new HashSet<InstructorCourse>();

    }
}
