using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class Jschema
    {
        public Jschema()
        {
            Sjschemas = new HashSet<Sjschema>();
        }

        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string SchemaNo { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Data { get; set; } = null!;
        public string? Alarm { get; set; }

        public virtual ICollection<Sjschema> Sjschemas { get; set; }
    }
}
