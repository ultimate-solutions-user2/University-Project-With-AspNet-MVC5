using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unvirsity_System.Models
{
    public class Professor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Signtific_Digree { get; set;}
        //[ForeignKey("Course")]
        //public int Course_ID { get; set; }
        public virtual ICollection<Course> Course { set; get; }

    }
}