using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unvirsity_System.Models
{
    public class Departments
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        //[ForeignKey("Course")]
        //public string Course_ID { get; set; }
        [ForeignKey("Faculity")]
        public int Faculty_ID { get; set; }
        public virtual ICollection<Course> Course { set; get; }
        public virtual Faculty Faculity { set; get; }

    }
}