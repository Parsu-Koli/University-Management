using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -----------------------------------------------
            // 1. CourseAssignment (Many-to-Many JOIN TABLE)
            // -----------------------------------------------
            modelBuilder.Entity<CourseAssignment>()
                .HasKey(ca => new { ca.CourseId, ca.InstructorId });  // Composite key

            modelBuilder.Entity<CourseAssignment>()
                .HasOne(ca => ca.Course)
                .WithMany(c => c.CourseAssignments)
                .HasForeignKey(ca => ca.CourseId);

            modelBuilder.Entity<CourseAssignment>()
                .HasOne(ca => ca.Instructor)
                .WithMany(i => i.CourseAssignments)
                .HasForeignKey(ca => ca.InstructorId);

            // -----------------------------------------------
            // 2. Enrollment (Student ↔ Course Many-to-Many)
            // -----------------------------------------------
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // -----------------------------------------------
            // 3. Instructor ↔ OfficeAssignment (One-to-One)
            // -----------------------------------------------
            modelBuilder.Entity<OfficeAssignment>()
                .HasKey(o => o.InstructorId);

            modelBuilder.Entity<OfficeAssignment>()
                .HasOne(o => o.Instructor)
                .WithOne(i => i.OfficeAssignment)
                .HasForeignKey<OfficeAssignment>(o => o.InstructorId);

            // -----------------------------------------------
            // 4. Department ↔ Instructor (Administrator)
            // -----------------------------------------------
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Instructor)
                .WithMany(i => i.Departments)
                .HasForeignKey(d => d.InstructorId)
                .IsRequired(false); // Administrator is optional
        }
    }
}
