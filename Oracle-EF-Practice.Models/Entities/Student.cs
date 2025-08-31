using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Models.Entities
{
    [Table("STUDENT")]
    public class STUDENT
    {
        [Key]
        [Column("STUDENTID")]
        public int STUDENTID { get; set; }

        [Column("FIRSTNAME")]
        public string FIRSTNAME { get; set; }

        [Column("LASTNAME")]
        public string LASTNAME { get; set; }

        [Column("EMAIL")]
        public string EMAIL { get; set; }

        [Column("ENROLLMENTDATE")]
        public DateTime ENROLLMENTDATE { get; set; }

        //public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
