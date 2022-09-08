using Microsoft.EntityFrameworkCore;
using StudentManagement.Core.Domain.Common;
using StudentManagement.Core.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentManagement.Infrastructure.Persistence.Contexts
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        #region DbSets
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Student_Subject> Student_Subjects { get; set; }
        public virtual DbSet<Student_List> Student_Lists { get; set; }

        #endregion

        //FLUENT API
        public override Task<int> SaveChangesAsync(CancellationToken ct = new())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(ct);
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            #region tables

            mb.Entity<Student>()
                .ToTable("Students");

            mb.Entity<Subject>()
                .ToTable("Subjects");

            mb.Entity<Student_Subject>()
                .ToTable("Student_Subjects");

            mb.Entity<Student_List>()
                .ToTable("Student_Lists");

            #endregion

            #region primary keys

            mb.Entity<Student>()
                .HasKey(e => e.Id);

            mb.Entity<Subject>()
                .HasKey(e => e.Id);

            mb.Entity<Student_Subject>()
                .HasKey(e => e.Id);

            mb.Entity<Student_List>()
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

            #region Student_List

            mb.Entity<Student_List>()
                .Property(p => p.StudentId)
                .IsRequired();

            mb.Entity<Student_List>()
                .Property(p => p.Present)
                .IsRequired();

            mb.Entity<Student_List>()
                .Property(p => p.Excuse)
                .IsRequired();

            mb.Entity<Student_List>()
                .Property(p => p.Ausence)
                .IsRequired();

            #endregion

            #endregion
        }
    }
}
