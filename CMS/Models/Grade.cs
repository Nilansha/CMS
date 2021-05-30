using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class Grade
    {
        [Key]
        public int Grade_Id { get; set; }

        public string Grade_Des { get; set; }

        public int Grade_Status { get; set; }
    }
}