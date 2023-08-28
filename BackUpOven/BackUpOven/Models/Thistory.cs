using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class Thistory
    {
        public long Id { get; set; }
        public DateTime Time { get; set; }
        public float PlatTemp { get; set; }
        public float InTemp { get; set; }
        public int OvenId { get; set; }
        public int? SchemaId { get; set; }

        public virtual Ovens Oven { get; set; } = null!;
    }
}
