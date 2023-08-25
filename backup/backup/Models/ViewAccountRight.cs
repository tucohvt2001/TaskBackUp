using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class ViewAccountRight
    {
        public int FunctionId { get; set; }
        public string ModuleName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Fvalue { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; } = null!;
        public int? Value { get; set; }
    }
}
