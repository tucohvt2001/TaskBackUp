using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class SdataHistory
    {
        public long Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int OvenId { get; set; }
        public string Data { get; set; } = null!;
        public bool? Valid { get; set; }

        public virtual Ovens Oven { get; set; } = null!;
    }
}
