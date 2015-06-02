using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstMigrationsDemo.CourseCatalog
{
public class Building
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BuildingID { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<Course> Courses { get; set; }
}
}
