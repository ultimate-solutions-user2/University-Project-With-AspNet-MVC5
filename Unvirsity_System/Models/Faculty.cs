using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unvirsity_System.Models
{
    public partial class Faculty
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name  { get; set; }
        public string Telephon { get; set; }
        public int Min_Digree { get; set; }
        public int Costs { get; set; }
  
       
        public byte [] Image { get; set; }
        public string Faculty_Detailes { get; set; }
        public string Required_Document { get; set; }
        [ForeignKey("Branch")]
        public int branch_ID { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<Departments> Departments { set; get; }
        public virtual ICollection<Submit_Student> SubmitStudent { set; get; }


    }
}