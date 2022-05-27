using System.ComponentModel.DataAnnotations;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.UserAccess
{
    public class Role : EntityBase
    {
        [DataType(DataType.Text), MaxLength(256),
        Display(Name ="Role Name")]
        public string Name { get; set; } = null!;
        [MaxLength(256)]
        public string NormalizedName { get; set; } = null!;
        public string ConcurrencyStamp { get; set; } = null!;

        public virtual ICollection<RoleClaim> RoleClaims { get; set; } = null!;
        public virtual ICollection<UserRole> UserRoles { get; set; } = null!;
    }
}