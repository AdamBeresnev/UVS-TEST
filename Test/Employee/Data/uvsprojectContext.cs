using Microsoft.EntityFrameworkCore;
using EmployeeManager.Models;
using System;

namespace EmployeeManager.Data
{
    public partial class uvsprojectContext : DbContext
    {
        public uvsprojectContext()
        {
        }

        public uvsprojectContext(DbContextOptions<uvsprojectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionStr = Environment.GetEnvironmentVariable("connectionString")
                    ?? throw new Exception("You need to set the connection string before running the program");

                optionsBuilder.UseNpgsql(connectionStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Employeeid);

                entity.ToTable("employees");

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.Employeename)
                    .HasMaxLength(128)
                    .HasColumnName("employeename");

                entity.Property(e => e.Employeesalary).HasColumnName("employeesalary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
