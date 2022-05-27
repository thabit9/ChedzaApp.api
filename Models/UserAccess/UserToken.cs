using System.ComponentModel.DataAnnotations;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.UserAccess
{
    public class UserToken : EntityBase
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.Text), MaxLength(128),
         Display(Name = "Login Provider")]
        public string LoginProvider { get; set; } = null!;
        [Required]
        [DataType(DataType.Text), MaxLength(128),
         Display(Name = "User Token Name")]
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}