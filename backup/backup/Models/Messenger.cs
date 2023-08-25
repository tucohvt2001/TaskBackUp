using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class Messenger
    {
        public int Id { get; set; }
        public DateTime? DateAdded { get; set; }
        public string? Name { get; set; }
        public int Type { get; set; }
        public string? AccessToken { get; set; }
        public int MessageType { get; set; }
        public string? TagNames { get; set; }
        public string? ReservedTagNames { get; set; }
        public string? Jdata { get; set; }
        public bool? Enabled { get; set; }
    }
}
