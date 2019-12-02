using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unvirsity_System.Models
{
    public partial class Submit_Student
    {
        public int ID { get; set; }
     /// [Required]
        public string The_name_is_quadrant { get; set; }
       // [Required]
        public string Total_General_Secondary_Degrees { get; set; }

        public string Address { get; set; }

        public string Telephon { get; set; }
        //public string graduation_certificate { get; set; }
        //[DisplayName("Upload_certificate")]
        [DisplayName("Upload File")]
        public byte[] image { set; get; }

        [ForeignKey("Faculity")]
        public int Faculty_ID { get; set; }
        public virtual Faculty Faculity { set; get; }
    }
}