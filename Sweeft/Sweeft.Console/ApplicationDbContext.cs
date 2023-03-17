using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sweeft.Console.Models;
using System.Security.Cryptography.X509Certificates;

namespace Sweeft.Console
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-E70FG99\\SQLEXPRESS;Database=SweefSchoolDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasMany(teacher => teacher.Pupils)
                .WithMany(pupil => pupil.Teachers)

                .UsingEntity<Dictionary<string, object>>(
                    "TeacherPupil",
                    tp => tp.HasOne<Pupil>().WithMany().HasForeignKey("PupilID"),
                    tp => tp.HasOne<Teacher>().WithMany().HasForeignKey("TeacherID"));


            modelBuilder.Entity<Teacher>().HasData(
                    new Teacher()
                    {
                        TeacherId = 1,
                        FirstName = "Nika",
                        LastName = "Chkhartishvili",
                        Gender = 'M',
                        Subject = "History",
                    },
                    new Teacher()
                    {
                        TeacherId = 2,
                        FirstName = "Zurab",
                        LastName = "Zurabishvili",
                        Gender = 'M',
                        Subject = "Biology",
                    }
                );


            modelBuilder.Entity<Pupil>().HasData(
                    new Pupil()
                    {
                        PupilID = 1,
                        FirstName = "Giorgi",
                        LastName = "Giorgadze",
                        Gender = 'M',
                        Class = "SE-123"
                    },
                    new Pupil()
                    {
                        PupilID = 2,
                        FirstName = "Aleksandre",
                        LastName = "Maisuradze",
                        Gender = 'M',
                        Class = "SE-123"
                    },
                    new Pupil()
                    {
                        PupilID = 3,
                        FirstName = "Mariam",
                        LastName = "Davitashvili",
                        Gender = 'F',
                        Class = "SE-123"
                    }
                );
        }

    }
}
