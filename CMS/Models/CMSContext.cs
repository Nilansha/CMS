using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class CMSContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CMSContext() : base("name=CMSContext")
        {
        }

        public System.Data.Entity.DbSet<CMS.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<CMS.Models.Subject> Subjects { get; set; }

        public System.Data.Entity.DbSet<CMS.Models.Teacher> Teachers { get; set; }

        public System.Data.Entity.DbSet<CMS.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<CMS.Models.Grade> Grades { get; set; }
    }
}
