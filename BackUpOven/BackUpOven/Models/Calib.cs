using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class Calib
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int OvenId { get; set; }
        public int InTemp { get; set; }
        public int PlatTemp { get; set; }

        public virtual Ovens Oven { get; set; } = null!;
    }
}
