using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class Account
    {
        public Account()
        {
            AccountRights = new HashSet<AccountRight>();
            Sessions = new HashSet<Session>();
        }

        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string AccountName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsLocked { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<AccountRight> AccountRights { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
