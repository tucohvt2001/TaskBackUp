using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class Mold
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; } = null!;
        public string MoldNo { get; set; } = null!;
        public int Cavity { get; set; }
        public int VersionId { get; set; }
    }
}
