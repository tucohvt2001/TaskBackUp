using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class Trigger
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int TriggerType { get; set; }
        public DateTime StartDateTime { get; set; }
        public int Recurrence { get; set; }
        public int RecurEvery { get; set; }
        public DateTime? NextDateTime { get; set; }
        public DateTime? DateOfExpiry { get; set; }
        public bool Enabled { get; set; }
        public bool Repeatable { get; set; }
        public int RepeatEvery { get; set; }
        public int TaskId { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Task Task { get; set; } = null!;
    }
}
