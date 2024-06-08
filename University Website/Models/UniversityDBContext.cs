using Microsoft.EntityFrameworkCore;

namespace University_Website.Models
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<AcademicProgram> AcademicPrograms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentResource> StudentResources { get; set; }
        public DbSet<StudentOrganization> StudentOrganizations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }

    }
}
