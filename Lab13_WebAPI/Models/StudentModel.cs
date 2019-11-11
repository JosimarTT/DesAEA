using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab13_WebAPI.Models
{
    public class StudentModel
    {
        public int studentID { get; set; }
        public int studentCode { get; set; }
        public string studentName { get; set; }
        public string studentLastName { get; set; }
        public string studentAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}