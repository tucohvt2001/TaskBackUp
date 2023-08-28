using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class Function
    {
        public Function()
        {
            AccountRights = new HashSet<AccountRight>();
        }

        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; } = null!;
        public string ModuleName { get; set; } = null!;
        public int Fvalue { get; set; }

        public virtual ICollection<AccountRight> AccountRights { get; set; }
    }
}
