using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11_Domain
{
    public class Student
    {
        [Key]
        public int studentID { get; set; }
        public int studentCode { get; set; }
        [Required]
        public string studentName { get; set; }
        public string studentLastName { get; set; }
        [Required]
        public string studentAddress { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "DateTime2")]
        public DateTime? UpdatedDate { get; set; }        
    }
}
