using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class Branch
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; } = null!;
    }
}
