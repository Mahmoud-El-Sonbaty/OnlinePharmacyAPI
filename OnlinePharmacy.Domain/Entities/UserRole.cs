using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using OnlinePharmacy.Domain.Extensions;
using OnlinePharmacy.Domain.Interfaces;

namespace OnlinePharmacy.Domain.Entities
{
    public class UserRole : IdentityUserRole<Guid>, IAuditEntity<Guid>
    {
        public UserRole() => UserRoleId = UuidV7.NewGuid();
        [NotMapped]
        public Guid Id { get => UserRoleId; set => UserRoleId = value; }
        public Guid UserRoleId { get; set; }
        public Role? Role { get; set; }
        public User? User { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
