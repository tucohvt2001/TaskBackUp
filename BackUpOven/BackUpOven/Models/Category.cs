using System;
using System.Collections.Generic;

namespace BackUpOven.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseParent = new HashSet<Category>();
            ProductDefs = new HashSet<ProductDef>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual Category? Parent { get; set; }
        public virtual ICollection<Category> InverseParent { get; set; }
        public virtual ICollection<ProductDef> ProductDefs { get; set; }
    }
}
