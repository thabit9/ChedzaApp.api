using System.ComponentModel.DataAnnotations;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.UserAccess
{
    public class UserRole : EntityBase
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }
        public bool Enable { get; set; }
    }
}