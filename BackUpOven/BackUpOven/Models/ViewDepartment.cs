using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class ViewDepartment
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? TotalUsers { get; set; }
    }
}
