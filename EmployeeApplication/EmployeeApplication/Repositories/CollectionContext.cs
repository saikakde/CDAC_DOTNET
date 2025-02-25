﻿using EmployeeApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApplication.Repositories
{
	public class CollectionContext : DbContext
	{
		public CollectionContext() { }

		public DbSet<Employee> Employees { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionString = "server=localhost;port=3306;user=root;password=12345;database=employeemanagement";
			optionsBuilder.UseMySQL(connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Employee>(entity =>
			{
				entity.HasKey(e=>e.id);
				entity.Property(e => e.name);
				entity.Property(e => e.reg_date);
				entity.Property(e => e.address);
				entity.Property(e=>e.mob_num);
				entity.Property(e=>e.email);
				entity.Property(e => e.password);
			});
			modelBuilder.Entity<Employee>().ToTable("Employee");
		}
	}
}
