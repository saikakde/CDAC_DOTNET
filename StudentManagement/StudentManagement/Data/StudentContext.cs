using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using System.Collections.Generic;
namespace StudentManagement.Data
{

    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }

}
