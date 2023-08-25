using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class Shiftwork
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; } = null!;
        public TimeSpan Start { get; set; }
        public TimeSpan Finish { get; set; }
    }
}
