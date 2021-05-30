using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class Subject
    {
        [Key]
        public int Subject_Id { get; set; }

        public string Subject_Name { get; set; }

        public int Subject_Status { get; set; }
    }
}