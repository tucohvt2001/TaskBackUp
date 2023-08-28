using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class TaskHistory
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int TaskId { get; set; }
        public string? Key { get; set; }
        public string Message { get; set; } = null!;

        public virtual Task Task { get; set; } = null!;
    }
}
