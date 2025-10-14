﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using MVC;
using MVC.Models;

namespace MVC.Context
{
    public class SchoolContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=MVC;Trusted_Connection=True;Encrypt=False");
        }
        public DbSet<Models.Student> Students { get; set; }
        public DbSet<Models.Department> departments { get; set; }
        public DbSet<Models.Instructor> instructors { get; set; }
        public DbSet<Models.Course> courses { get; set; }
        public DbSet<Models.StudentCourse> studentcourses { get; set; }
        public DbSet<Models.InstructorCourse> instructorcourses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });
            mb.Entity<InstructorCourse>().HasKey(ic => new { ic.InstructorId, ic.CourseId });

            mb.Entity<StudentCourse>().HasOne(sc => sc.Student).WithMany(s => s.StudentCourses).HasForeignKey(sc => sc.StudentId);
            mb.Entity<StudentCourse>().HasOne(sc => sc.Course).WithMany(sc => sc.StudentCourses).HasForeignKey(sc => sc.CourseId);
            mb.Entity<Department>().HasMany(d => d.Students).WithOne(s => s.department).HasForeignKey(s => s.DeptId);


            mb.Entity<InstructorCourse>().HasOne(sc => sc.Instructor).WithMany(s => s.InstructorCourses).HasForeignKey(sc => sc.InstructorId);
            mb.Entity<InstructorCourse>().HasOne(sc => sc.Course).WithMany(sc => sc.InstructorCourses).HasForeignKey(sc => sc.CourseId);
            mb.Entity<Department>().HasMany(d => d.Instructors).WithOne(s => s.Department).HasForeignKey(i => i.DeptId);
        }
    }
}
