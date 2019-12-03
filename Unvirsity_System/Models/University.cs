using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// asmaa
namespace Unvirsity_System.Models
{
    public partial class University
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] image { get; set; }
        public string Location { get; set; }
        public string address { get; set; }
        public int Telephon { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Location> Locations { get; set; }



    }
}
