using System.ComponentModel.DataAnnotations;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.UserAccess
{
    public class UserClaim : EntityBase
    {
        [Required]
        public int UserId { get; set; }
        public string ClaimType { get; set; } = null!;
        public string ClaimValue { get; set; } = null!; 
    }
}