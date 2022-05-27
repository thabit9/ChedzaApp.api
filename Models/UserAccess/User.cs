using System.Reflection;
using System.ComponentModel.DataAnnotations;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.UserAccess
{
    public class User : EntityBase
    {
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="UserName")]
        public string UserName { get; set; }  = null!;
        [MaxLength(256)]
        public string NormalizedUserName { get; set; } = null!;
        [Required, EmailAddress,
         DataType(DataType.Text), MaxLength(256),
         Display(Name ="User Email")]
        public string Email { get; set; } = null!;
        [MaxLength(256)]
        public string NormalizedEmail { get; set; } = null!;
        [Required]
        public bool EmailConfirmed { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [StringLength(256, ErrorMessage ="Must be between 8 to 256 characters", MinimumLength =8)]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string PasswordHash { get; set; } = null!;
        [DataType(DataType.DateTime)]
        [Display(Name ="Date Created")]
        public DateTime CreationDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name ="Date Approved")]
        public DateTime ApprovalDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name ="Last Login Date")]
        public DateTime LastLoginDate { get; set; }
        public bool IsLocked { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Password Question")]
        public string PasswordQuestion { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name = "Password Answer")]
        public string PasswordAnswer { get; set; } = null!;
        public string ActivationToken { get; set; } = null!;
        public string SecurityStamp { get; set; } = null!;
        public string ConcurrencyStamp { get; set; } = null!;
        [Required(ErrorMessage = "Telephone no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Telephone no.")]
        public string PhoneNumber { get; set; } = null!;
        [Required]
        public bool PhoneNumberConfirmed { get; set; }
        [Required]
        public bool TwoFactorEnabled { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Lockout End")]
        public DateTime LockoutEnd { get; set; }
        [Required]
        public bool LockoutEnabled { get; set; }
        [Required]
        public int AccessFailedCount { get; set; } 

        public virtual ICollection<UserLogin> Logins { get; } = null!;   
        public virtual ICollection<UserRole> Roles { get; } = null!;
        public virtual ICollection<UserClaim> UserClaims { get; set; } = null!;
        public virtual ICollection<UserToken> UserTokens { get; set; } = null!;


    }
}