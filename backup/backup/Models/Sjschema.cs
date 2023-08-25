using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class Sjschema
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int OvenId { get; set; }
        public int JschemaId { get; set; }
        public string? Alarm { get; set; }

        public virtual Jschema Jschema { get; set; } = null!;
        public virtual Ovens Oven { get; set; } = null!;
    }
}
