using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Domain.Entities;

namespace StudentManagement.Infrastructure.Persistence.Contexts
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Student_Subject> Student_Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            #region tables

            mb.Entity<Student>()
                .ToTable("Students");

            mb.Entity<Subject>()
                .ToTable("Subjects");

            mb.Entity<Student_Subject>()
                .ToTable("Student_Subjects");

            #endregion

            #region primary keys

            mb.Entity<Student>()
                .HasKey(e => e.Id);

            mb.Entity<Subject>()
                .HasKey(e => e.Id);

            mb.Entity<Student_Subject>()
                .HasKey(e => e.Id);

            #endregion

            #region relations

            //mb.Entity<SaleType>()
            //    .HasMany<Property>(t => t.Properties)
            //    .WithOne(p => p.SaleType)
            //    .HasForeignKey(p => p.SaleTypeId)
            //    .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region property configurations

            #region Student
            mb.Entity<Student>()
                .Property(p => p.FirstName)
                .IsRequired();

            mb.Entity<Student>()
                .Property(p => p.LastName)
                .IsRequired();
            #endregion

            #region Subject

            mb.Entity<Subject>()
                .Property(p => p.Name)
                .IsRequired();

            #endregion

            #region Student_Subject

            mb.Entity<Student_Subject>()
                .Property(p => p.StudentId)
                .IsRequired();

            mb.Entity<Student_Subject>()
                .Property(p => p.SubjectId)
                .IsRequired();

            mb.Entity<Student_Subject>()
                .Property(p => p.Grade)
                .IsRequired();

            #endregion

            #endregion
        }
    }
}
