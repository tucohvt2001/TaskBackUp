using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class OvenSetting
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int OvenId { get; set; }
        public int? ProductDefId { get; set; }
        public float InRunTemp { get; set; }
        public float InStartTemp { get; set; }
        public float DeltaTemp { get; set; }
        public float DeltaTime { get; set; }
        public float MinCycleTime { get; set; }
        public float MaxCycleTime { get; set; }
        public float SlopeLength { get; set; }
        public string? Code { get; set; }
    }
}
