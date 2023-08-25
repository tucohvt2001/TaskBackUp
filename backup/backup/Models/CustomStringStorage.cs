using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class CustomStringStorage
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public string Key { get; set; } = null!;
        public string? Value { get; set; }
    }
}
