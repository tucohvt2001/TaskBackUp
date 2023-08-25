using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class PowerOff
    {
        public long Id { get; set; }
        public byte[]? Time { get; set; }
    }
}
