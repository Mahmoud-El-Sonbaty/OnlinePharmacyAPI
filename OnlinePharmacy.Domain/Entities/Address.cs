using System.ComponentModel.DataAnnotations.Schema;
using OnlinePharmacy.Domain.Interfaces;

namespace OnlinePharmacy.Domain.Entities
{
    public class Address : IAuditEntity<Guid>
    {
        [NotMapped]
        public Guid Id { get => AddressId; set => AddressId = value; }

        public Guid AddressId { get; set; }

        public Guid UserId { get; set; }
        
        public Guid CityId { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public bool IsMain { get; set; }

        public string? PostalCode { get; set; }
        
        public string AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public string? AppartmentNumber { get; set; }

        public string? FloorNumber { get; set; }

        public virtual City City { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
