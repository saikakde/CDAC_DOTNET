using EmpWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpWebApp.Repository
{
    public class CollectionContext : DbContext
    {
        public DbSet<Emp> emps { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cn = "server=localhost;port=3306;username=root;password=12345;database=studentms";
            optionsBuilder.UseMySQL(cn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Emp>(Entity =>
            {
                Entity.HasKey(e => e.id);
                Entity.Property(e => e.name);
                Entity.Property(e => e.email);
                Entity.Property(e => e.phone);
                Entity.Property(e => e.address);
                Entity.Property(e => e.status);
                Entity.Property(e => e.salary);
          
            });
            modelBuilder.Entity<Emp>().ToTable("emp");
        }
    }
}
