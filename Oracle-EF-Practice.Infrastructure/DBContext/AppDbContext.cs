using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oracle_EF_Practice.Domain.Entities;

namespace Oracle_EF_Practice.Infrastructure.DBContext
{ 
    public class AppDbContext : DbContext
    {
        private readonly ILogger<AppDbContext> _logger;
        public AppDbContext(DbContextOptions<AppDbContext> options, ILogger<AppDbContext> logger) : base(options)
        {
            _logger = logger;
            try
            {
                // Attempt to open connection
                Database.OpenConnection();

                _logger.LogInformation("Successfully connected to Oracle Database (from AppDbContext).");

                Database.CloseConnection();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                _logger.LogError(ex, "Failed to connect to Oracle Database (from AppDbContext). Oracle Error: {ErrorMessage}", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while connecting to Oracle Database (from AppDbContext): {ErrorMessage}", ex.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            //modelBuilder.Entity<CourseInstructor>().HasNoKey();

        }

        public DbSet<Student> Student { get; set; }

        public DbSet<Course> Course { get; set; }

        //public DbSet<Enrollment> Enrollments { get; set; }

        //public DbSet<CourseInstructor> CourseInstructors { get; set; }

        //public DbSet<Instructor> Instructors { get; set; }

        //public DbSet<Grade> Grades { get; set; }
    }
}
