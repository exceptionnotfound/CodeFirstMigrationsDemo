﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMigrationsDemo.CourseCatalog
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
