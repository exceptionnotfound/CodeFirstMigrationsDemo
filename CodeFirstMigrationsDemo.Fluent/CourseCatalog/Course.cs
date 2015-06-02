using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMigrationsDemo.Fluent.CourseCatalog
{
    public class Course
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public int TeacherID { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
