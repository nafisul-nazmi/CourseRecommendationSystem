using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRS.Entity.Models
{
    public class Admin : BaseEntity
    {
        // Database fields
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
