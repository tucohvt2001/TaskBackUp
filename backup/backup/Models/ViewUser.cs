using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class ViewUser
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string? Title { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Notes { get; set; }
        public string? Avatar { get; set; }
        public int? DepartmentId { get; set; }
        public string? EmployeeNo { get; set; }
        public string? Department { get; set; }
        public int? BranchId { get; set; }
    }
}
