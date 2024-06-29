using Microsoft.EntityFrameworkCore;

namespace SchoolApp.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Student entity
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfBirth)
                    .IsRequired();
            });

            // Optionally, seed initial data
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.Now },
                new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = DateTime.Now }
            );
        }
    }
}
