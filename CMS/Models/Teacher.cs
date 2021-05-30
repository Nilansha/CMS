using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class Teacher
    {
        [Key]
        public int Teacher_Id { get; set; }

        public string Teacher_Name { get; set; }

        public DateTime Teacher_DOB { get; set; }

        public int Teacher_Status { get; set; }
    }
}