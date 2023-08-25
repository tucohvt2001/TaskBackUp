using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class CustomModule
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsManaged { get; set; }
        public string ProgId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? DllName { get; set; }
    }
}
