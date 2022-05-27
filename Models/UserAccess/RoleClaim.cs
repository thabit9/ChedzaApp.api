using System.ComponentModel.DataAnnotations;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.UserAccess
{
    public class RoleClaim : EntityBase 
    {
        [Required]
        public int RoleId { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name = "Claim Type")]
        public string ClaimType { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name = "Claim Value")]
        public string ClaimValue { get; set; } = null!;
    }
}