using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChedzaApp.api.Models.UserAccess
{
    public class UserLogin
    {
        [Required]
        //[Key]
        [Column(Order = 1)]
        [DataType(DataType.Text), MaxLength(128),
         Display(Name = "Login Provider")]
        public string LoginProvider { get; set; } = null!;
        [Required]
        //[Key]
        [Column(Order = 2)]
        [DataType(DataType.Text), MaxLength(128),
         Display(Name = "Provider Key")]
        public string ProviderKey { get; set; } = null!;
        public string ProviderDisplayName { get; set; } = null!;
        public string ConcurrencyStamp { get; set; } = null!;
        [Required]
        public int UserId { get; set; }
    }
}