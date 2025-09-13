using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Domain.Entities
{
    [Table("COURSE")]
    public class Course
    {
        [Key]
        [Column("COURSEID")]
        public int CourseId { get; set; }

        [Column("TITLE")]
        public string Title { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [Column("CREDITS")]
        public double Credits { get; set; }

        [Column("MAXSTUDENTS")]
        public int MaxStudents { get; set; }

        //public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        //public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
    }
}
