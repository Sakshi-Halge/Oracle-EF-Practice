using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_EF_Practice.Domain.Entities
{
    [Table("Grade")]
    public class Grade
    {
        [Key]
        [Column("GradeId")]
        public int GradeId { get; set; }

        [Column("GradeName")]
        public string GradeName { get; set; }
    }
}
