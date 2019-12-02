using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unvirsity_System.Models
{
    public class Location
    {
        public int ID { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        [ForeignKey("University")]
        public int university_ID { get; set; }
        public virtual University University { get; set; }
    }
}