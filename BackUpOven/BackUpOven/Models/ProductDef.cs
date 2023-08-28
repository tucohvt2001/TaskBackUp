using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class ProductDef
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
        public string? Type { get; set; }
        public float InTemp { get; set; }
        public float? DeltaInTemp { get; set; }
        public float CycleTime { get; set; }
        public float? DeltaCycleTime { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
