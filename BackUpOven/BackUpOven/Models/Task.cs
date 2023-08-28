using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class Task
    {
        public Task()
        {
            TaskHistories = new HashSet<TaskHistory>();
            Triggers = new HashSet<Trigger>();
        }

        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Status { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateModified { get; set; }
        public string? Author { get; set; }
        public bool? Legacy { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<TaskHistory> TaskHistories { get; set; }
        public virtual ICollection<Trigger> Triggers { get; set; }
    }
}
