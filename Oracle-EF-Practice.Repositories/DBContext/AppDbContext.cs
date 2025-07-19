using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oracle_EF_Practice.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Repositories.DBContext
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

                // --- CRITICAL VERIFICATION QUERIES ---
                // Cast to OracleConnection to access provider-specific features if needed,
                // but simple ExecuteScalar should work for standard SQL.
                var connection = Database.GetDbConnection();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT USER FROM DUAL";
                    string connectedUser = command.ExecuteScalar()?.ToString();
                    _logger.LogInformation("Connected user from ASP.NET: {ConnectedUser}", connectedUser);

                    command.CommandText = "SELECT SYS_CONTEXT('USERENV', 'CON_NAME') FROM DUAL";
                    string pdbName = command.ExecuteScalar()?.ToString();
                    _logger.LogInformation("Connected PDB from ASP.NET: {PDBName}", pdbName);
                }
                // --- END CRITICAL VERIFICATION QUERIES ---

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
            modelBuilder.Entity<Student>().ToTable("STUDENT", schema: "SYSTEM");
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT", "SYSTEM"); // Ensure table mapping is consistent here

                // Map properties to their exact column names in the database
                entity.Property(s => s.StudentId).HasColumnName("STUDENTID"); // Assuming StudentId is primary key
                entity.Property(s => s.FirstName).HasColumnName("FIRSTNAME");
                entity.Property(s => s.LastName).HasColumnName("LASTNAME");
                entity.Property(s => s.Email).HasColumnName("EMAIL");
                entity.Property(s => s.EnrollmentDate).HasColumnName("ENROLLMENTDATE");
                // Add all other properties of Student here
            });
            //modelBuilder.Entity<CourseInstructor>().HasNoKey();

        }

        public DbSet<Student> Student { get; set; }

        //public DbSet<Course> Courses { get; set; }

        //public DbSet<Enrollment> Enrollments { get; set; }

        //public DbSet<CourseInstructor> CourseInstructors { get; set; }

        //public DbSet<Instructor> Instructors { get; set; }

        //public DbSet<Grade> Grades { get; set; }
    }
}
