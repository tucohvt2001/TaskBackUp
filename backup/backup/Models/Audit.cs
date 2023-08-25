using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class Audit
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public long? DataId { get; set; }
        public string UnitNo { get; set; } = null!;
        public string SchemaNo { get; set; } = null!;
        public string Property { get; set; } = null!;
        public string Message { get; set; } = null!;
        public bool Ack { get; set; }
        public string? AckBy { get; set; }
        public DateTime? DateAck { get; set; }
        public byte Status { get; set; }
    }
}
