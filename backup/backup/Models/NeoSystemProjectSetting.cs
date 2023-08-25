using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class NeoSystemProjectSetting
    {
        public string Guid { get; set; } = null!;
        public string? Version { get; set; }
    }
}
