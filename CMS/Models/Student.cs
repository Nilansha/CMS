using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }

        public string Student_Name { get; set; }

        public DateTime Student_DOB { get; set; }

        public int Student_Status { get; set; }
    }
}