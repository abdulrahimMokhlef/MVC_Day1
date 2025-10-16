using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class StudentCourse
    {
        [Key]
        public int StudentId { get; set; }
        [Key]
        public int CourseId { get; set; }
        public double Grade { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; } = new Student();
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = new Course();
    }
}
