using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class Course
    {
        [Key]
        public int Course_Id { get; set; }

        public string Course_Name { get; set; }

        public int Course_Status { get; set; }
    }
}