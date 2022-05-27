using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebArchitecture.StudentCheckList.Entity
{
    public class StudentCheckListDBContext : DbContext
    {
        public StudentCheckListDBContext(DbContextOptions<StudentCheckListDBContext> options) :
           base(options)
        { }

        public DbSet<Attendance> Attendances { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Attendance>()
                .HasKey(od => od.Id); 

            modelBuilder.Entity<Attendance>()
                .Property(c => c.StudentCod)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Attendance>()
                .Property(c => c.ClassCod)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Attendance>()
                .Property(c=>c.CheckDate)
                .HasDefaultValueSql("getdate()");

        }
    }
}
