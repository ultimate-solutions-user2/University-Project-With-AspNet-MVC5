using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unvirsity_System.Models
{
    public class Branch
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID{ get; set; }
        public string Name { get; set; }
        [ForeignKey("University")]
        public int university_ID { get; set; }
        public virtual University University { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }


    }
}