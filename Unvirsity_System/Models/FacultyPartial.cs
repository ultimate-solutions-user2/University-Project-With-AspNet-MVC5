﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unvirsity_System.Models
{
    public partial class Faculty
    {
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}