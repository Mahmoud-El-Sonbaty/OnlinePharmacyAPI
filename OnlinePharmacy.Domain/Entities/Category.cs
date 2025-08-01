﻿using System.ComponentModel.DataAnnotations.Schema;
using OnlinePharmacy.Domain.Interfaces;

namespace OnlinePharmacy.Domain.Entities
{
    public class Category : IAuditEntity<Guid>
    {
        [NotMapped]
        public Guid Id { get => CategoryId; set => CategoryId = value; }

        public Guid CategoryId { get; set; }
        
        public string CreatedBy { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public string? UpdatedBy { get; set; }
        
        public DateTime? UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public string Name_Ar { get; set; }

        public string Name_En { get; set; }

        public string Order { get; set; }
        
        public Guid? ParentId { get; set; }
        
        public string? Description_Ar { get; set; }
        
        public string? Description_En { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsParent { get; set; } = false;
        
        public string? IconUrl { get; set; }

        public virtual Category ParentCategory { get; set; } = null!;

        public virtual ICollection<Category> SubCategories { get; set; } = [];
        
        public virtual ICollection<Product> Products { get; set; } = [];
    }
}
