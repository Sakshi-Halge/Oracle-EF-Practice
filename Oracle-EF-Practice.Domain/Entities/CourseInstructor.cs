using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Domain.Entities
{
    [Table("CourseInstructor")]
    public class CourseInstructor
    {
        [Column("CourseId")]
        public int CourseId { get; set; }

        [Column("InstructorId")]
        public int InstructorId { get; set; }
    }
}
