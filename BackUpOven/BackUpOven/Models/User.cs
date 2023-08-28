using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            Tasks = new HashSet<Task>();
        }

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
        public int Deleted { get; set; }
        public int? BranchId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
