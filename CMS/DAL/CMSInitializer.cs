
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CMS.Models;

namespace ContosoUniversity.DAL
{
    public class CMSInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CMSContext>
    {
        protected override void Seed(CMSContext context)
        {
            var courses = new List<Course>
            {
            new Course{Course_Name="Information Technology", Course_Status=1},
            new Course{Course_Name="Machanical", Course_Status=1},
            new Course{Course_Name="Hospitality Management", Course_Status=1},
            new Course{Course_Name="Sports Management", Course_Status=1}
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>
            {
            new Subject{Subject_Name="Networking", Subject_Status=1},
            new Subject{Subject_Name="Fluid Engineering", Subject_Status=1},
            new Subject{Subject_Name="Food and Beverages", Subject_Status=1},
            new Subject{Subject_Name="First Aids", Subject_Status=1},
            };
            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();
            
        }
    }
}