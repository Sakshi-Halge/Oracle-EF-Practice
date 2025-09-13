using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Domain.Entities
{
    [Table("STUDENT")]
    public class Student
    {
        [Key]
        [Column("STUDENTID")]
        public int StudentID { get; set; }

        [Column("FIRSTNAME")]
        public string FirstName { get; set; }

        [Column("LASTNAME")]
        public string LASTNAME { get; set; }

        [Column("EMAIL")]
        public string EMAIL { get; set; }

        [Column("ENROLLMENTDATE")]
        public DateTime ENROLLMENTDATE { get; set; }

        //public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
