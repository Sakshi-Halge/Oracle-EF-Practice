using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Domain.Entities
{
    [Table("Enrollment")]
    public class Enrollment
    {
        [Key]
        [Column("EnrollmentId")]
        public int EnrollmentId { get; set; }

        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        [Column("GradeId")]
        public int GradeId { get; set; }

        [Column("EnrollmentDate")]
        public DateTime EnrollmentDate { get; set; }

        public virtual STUDENT STUDENT { get; set; }

        public virtual Course Course { get; set; }
    }
}
