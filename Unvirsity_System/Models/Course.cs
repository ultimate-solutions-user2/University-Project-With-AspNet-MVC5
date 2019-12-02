using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unvirsity_System.Models
{
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Max_Digree { get; set; }
        public int Min_Digree { get; set; }
        public int NO_OF_Hours { get; set; }
        public bool Is_Elective { get; set; }
        [ForeignKey("Departments")]
        public int Departments_ID { get; set; }
        [ForeignKey("Professor")]
        public int prof_id { get; set; }
        public virtual Professor Professor { get; set; }
        //public virtual ICollection<Professor> Professor { set; get; }
        public virtual Departments Departments { set; get; }

    }
}