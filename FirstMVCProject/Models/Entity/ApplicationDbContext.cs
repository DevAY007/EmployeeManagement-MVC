using Microsoft.EntityFrameworkCore;

namespace FirstMVCProject.Models.Entity

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> emlpoyees { get; set; }
		public DbSet<NextOfKin> NextKin { get; set; }
		public DbSet<EducationHistory> EduInformation { get; set; }
		public DbSet<HealthStatus> HealthStatus{ get; set; }
		public DbSet<CompanyRegistration> CompanyRegistration { get; set; }
    }
}
