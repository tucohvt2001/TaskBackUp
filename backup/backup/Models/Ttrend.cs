using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class Ttrend
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public float PlatTemp { get; set; }
        public float InTemp { get; set; }
        public int OvenId { get; set; }

        public virtual Ovens Oven { get; set; } = null!;
    }
}
