using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Student
    {
        [Key]
        

        public int SSN      { get ; set; }
        public string? Name     { get ; set ; }
        public int? Age         { get ; set; }
        public string? Image    { get ; set; }
        public string? Email    { get; set; }
        public string? Address  { get; set; }
        public int? DeptId { get; set; }
        [ForeignKey(nameof(DeptId))]

        public Department? Department { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();

    }
}
