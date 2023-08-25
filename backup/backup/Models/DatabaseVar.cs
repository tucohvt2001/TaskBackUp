using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class DatabaseVar
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int SchemaVer { get; set; }
        public int Part { get; set; }
        public int Planning { get; set; }
        public int SwLength { get; set; }
        public TimeSpan SwStartTime { get; set; }
        public int SwDuration { get; set; }
        public string? Name { get; set; }
        public int TimeZone { get; set; }
    }
}
