using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class ViewCategory
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
