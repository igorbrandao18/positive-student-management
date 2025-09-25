using Microsoft.EntityFrameworkCore;
using PositiveStudentManagement.Models;

namespace PositiveStudentManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Students");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.StudentId).IsRequired().HasMaxLength(50);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DateOfBirth).IsRequired();
                entity.Property(e => e.AddressType).IsRequired();
                entity.Property(e => e.Street).IsRequired().HasMaxLength(200);
                entity.Property(e => e.ZipCode).IsRequired().HasMaxLength(9);
                entity.Property(e => e.Number).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Complement).HasMaxLength(100);
                entity.Property(e => e.Grade).IsRequired().HasMaxLength(20);
                entity.Property(e => e.EducationLevel).HasMaxLength(50);
                entity.Property(e => e.FatherName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.MotherName).IsRequired().HasMaxLength(100);
            });
        }
    }
}
