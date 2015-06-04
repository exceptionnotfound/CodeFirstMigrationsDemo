using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMigrationsDemo.Fluent.CourseCatalog
{
    public class CourseCatalogContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAddress> StudentAddresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .Property(x => x.ID)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Student>()
                        .HasKey(x => x.ID);

            modelBuilder.Entity<Student>()
                        .Property(x => x.FirstName)
                        .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<Student>()
                        .Property(x => x.LastName)
                        .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<Student>()
                        .HasOptional(x => x.Address)
                        .WithRequired(x => x.Student);

            modelBuilder.Entity<StudentAddress>()
                        .HasKey(x => x.StudentID);

            modelBuilder.Entity<StudentAddress>()
                        .Property(x => x.StreetAddress)
                        .IsRequired();

            modelBuilder.Entity<StudentAddress>()
                        .Property(x => x.City)
                        .IsRequired();

            modelBuilder.Entity<StudentAddress>()
                        .Property(x => x.State)
                        .IsRequired();

            modelBuilder.Entity<StudentAddress>()
                        .Property(x => x.PostalCode)
                        .IsRequired();

            modelBuilder.Entity<Teacher>()
                        .HasKey(x => x.ID);

            modelBuilder.Entity<Teacher>()
                        .Property(x => x.ID)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Teacher>()
                        .Property(x => x.FirstName)
                        .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<Teacher>()
                        .Property(x => x.LastName)
                        .IsRequired()
                        .HasMaxLength(100);

            modelBuilder.Entity<Course>()
                        .HasKey(x => x.ID);

            modelBuilder.Entity<Course>()
                        .Property(x => x.ID)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Course>()
                        .Property(x => x.Name)
                        .IsRequired();

            modelBuilder.Entity<Teacher>()
                        .HasMany(x => x.Courses)
                        .WithRequired(x => x.Teacher)
                        .HasForeignKey(x => x.TeacherID);

            modelBuilder.Entity<Course>()
                        .HasMany(x => x.Students)
                        .WithMany(x => x.Courses)
                        .Map(c => c.MapLeftKey("StudentID")
                                    .MapRightKey("CourseID")
                                    .ToTable("StudentCourses"));
                        

            base.OnModelCreating(modelBuilder);
        }
    }
}
