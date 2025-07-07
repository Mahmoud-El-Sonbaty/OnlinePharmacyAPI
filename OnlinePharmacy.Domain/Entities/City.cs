using System.ComponentModel.DataAnnotations.Schema;
using OnlinePharmacy.Domain.Interfaces;

namespace OnlinePharmacy.Domain.Entities
{
    public partial class City : IAuditEntity<Guid>
    {
        [NotMapped]
        public Guid Id { get => CityId; set => CityId = value; }

        public Guid CityId { get; set; }

        public Guid StateId { get; set; }

        public string Name_En { get; set; } = null!;

        public string Name_Ar { get; set; } = null!;

        public bool IsActive { get; set; }

        public string Order { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual State State { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
