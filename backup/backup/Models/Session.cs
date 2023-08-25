using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class Session
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int AccountId { get; set; }
        public Guid Sid { get; set; }
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;

        public virtual Account Account { get; set; } = null!;
    }
}
