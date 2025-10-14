using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Student
    {
        [Key]
        public int ssn          { get ; set; }
        public string? name     { get ; set ; }
        public int? age         { get ; set; }
        public string? image    { get ; set; }
        public string? email    { get; set; }
        public string? address  { get; set; }
        public int? DeptId { get; set; }
        [ForeignKey(nameof(DeptId))]
        public Department department { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();

    }
}
