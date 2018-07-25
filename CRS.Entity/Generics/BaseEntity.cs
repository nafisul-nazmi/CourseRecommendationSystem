using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRS.Entity.Generics
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
    }
}
