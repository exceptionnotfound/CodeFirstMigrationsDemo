using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMigrationsDemo.CourseCatalog
{
    public class CourseCatalogContext : DbContext
    {
        public CourseCatalogContext() : base("name=NorthwindCodeFirst") { }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAddress> StudentAddresses { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
    }
}
