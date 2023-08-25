using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class AccountRight
    {
        public int AccountId { get; set; }
        public int FunctionId { get; set; }
        public DateTime DateAdded { get; set; }
        public int Value { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Function Function { get; set; } = null!;
    }
}
