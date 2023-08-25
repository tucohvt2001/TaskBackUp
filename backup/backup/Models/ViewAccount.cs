using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class ViewAccount
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string AccountName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsLocked { get; set; }
        public int? UserId { get; set; }
        public string? EmployeeNo { get; set; }
    }
}
