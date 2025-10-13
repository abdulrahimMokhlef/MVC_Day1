using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using MVC;
using MVC.Models;

namespace MVC.Context
{
    public class CompanyContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=MVC;Trusted_Connection=True;Encrypt=False");
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }


    }
}
