using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class InstructorCourse
    {
        [Key]
        public int InstructorId { get; set; }
        [Key]
        public int CourseId { get; set; }
        public int RateHour { get; set; }
        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; } = new Instructor();
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = new Course();
    }
}
