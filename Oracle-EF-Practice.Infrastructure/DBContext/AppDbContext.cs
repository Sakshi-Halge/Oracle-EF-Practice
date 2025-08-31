using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Oracle_EF_Practice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DbSet<STUDENT> STUDENT { get; set; }

        //public DbSet<Course> Courses { get; set; }

        //public DbSet<Enrollment> Enrollments { get; set; }

        //public DbSet<CourseInstructor> CourseInstructors { get; set; }

        //public DbSet<Instructor> Instructors { get; set; }

        //public DbSet<Grade> Grades { get; set; }
    }
}
