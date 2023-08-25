using System;
using System.Collections.Generic;

namespace backup.Models
{
    public partial class Ovens
    {
        public Ovens()
        {
            Calibs = new HashSet<Calib>();
            SdataHistories = new HashSet<SdataHistory>();
            Sjschemas = new HashSet<Sjschema>();
            Thistories = new HashSet<Thistory>();
            Ttrends = new HashSet<Ttrend>();
        }

        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string UnitNo { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int? SectionId { get; set; }
        public int SortId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool? ConnectEnabled { get; set; }
        public int? CalibId { get; set; }
        public bool SwCalibEnabled { get; set; }

        public virtual Section? Section { get; set; }
        public virtual ICollection<Calib> Calibs { get; set; }
        public virtual ICollection<SdataHistory> SdataHistories { get; set; }
        public virtual ICollection<Sjschema> Sjschemas { get; set; }
        public virtual ICollection<Thistory> Thistories { get; set; }
        public virtual ICollection<Ttrend> Ttrends { get; set; }
    }
}
