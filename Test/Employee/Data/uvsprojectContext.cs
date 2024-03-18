using Microsoft.EntityFrameworkCore;
using EmployeeManager.Models;

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
                optionsBuilder.UseNpgsql("Name=ConnectionStrings:Main");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasNoKey();

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
