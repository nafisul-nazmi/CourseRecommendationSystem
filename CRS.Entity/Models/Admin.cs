using CRS.Entity.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRS.Entity.Models
{
    public class Admin : BaseEntity
    {
        // Database fields
        [Column("AdminId")]
        [Key]
        public override int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
