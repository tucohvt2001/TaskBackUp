using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class NeoSystemTableVersion
    {
        public string StorageTableName { get; set; } = null!;
        public string? GuidString { get; set; }
        public long? SchemaVersion { get; set; }
        public long? DataVersionDesignTime { get; set; }
        public long? DataVersionRunTime { get; set; }
    }
}
