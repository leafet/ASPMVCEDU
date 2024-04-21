using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ASPMVCEDU.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Scheldue> scheldues { get; set; }
    }

    public class Teacher
    {
        public int TeacherId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Specialisation { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Adress { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public required string CourseName { get; set; }
        public required string Description { get; set; }
        public required int Duration { get; set; }
        public required int Price { get; set; }
    }

    public class Class
    {
        public int ClassId { get; set; }
        public required Course Course { get; set; }
        public required Teacher Teacher { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required int Duration { get; set; }
    }

    public class Registration
    {
        public int RegistrationId { get; set; }
        public required Class Class { get; set; }
        public required Student Student { get; set; }
        public required DateTime RegistrationDate { get; set; }
        public required int Mark { get; set; }
    }

    public class Scheldue
    {
        public int ScheldueId { get; set; }
        public required ICollection<Registration> Registrations { get; set; } = new List<Registration>();
    }
}
