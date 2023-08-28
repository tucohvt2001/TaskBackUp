using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class ViewSection
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string SectionNo { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
