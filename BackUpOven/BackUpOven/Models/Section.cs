using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class Section
    {
        public Section()
        {
            Ovens = new HashSet<Ovens>();
        }

        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string SectionNo { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Ovens> Ovens { get; set; }
    }
}
