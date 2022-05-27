using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;
using ChedzaApp.api.Models.BlogPosts;
using ChedzaApp.api.Models.UserAccess;

namespace ChedzaApp.api.Models.Shop
{
    public class Customer: EntityBase
    {
        public int UserId { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="First Name")]
        public string FirstName { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Last Name")]
        public string LastName { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256), 
         Display(Name ="Full Name")]
        public string FullName { get; set; } = null!;
        [Required(ErrorMessage = "Phone no. is required")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", 
         ErrorMessage = "Please enter valid Phone no.")]
        public string Phone { get; set; } = null!;
        [Required, EmailAddress,
         DataType(DataType.Text), MaxLength(256),
         Display(Name ="Customer Email")]
        public string Email { get; set; } = null!;
        [DataType(DataType.MultilineText), MaxLength(500),
         Display(Name ="Comments")]
        public string Comments { get; set; } = null!;



        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(UserId))]
        public User UserNavigation { get; set; } = null!; 
        #endregion
        #region Navigation Properties(Retrieves Many Record)
        //BlogPost 
        [InverseProperty(nameof(Post.CreatedBy))]
        public ICollection<Post> PostsWritten { get; set; } = null!;
        [InverseProperty(nameof(Post.UpdatedBy))]
        public ICollection<Post> PostsUpdated { get; set; } = null!;  
        //Shop
        [InverseProperty(nameof(Address.CustomerAddress))]
        public IEnumerable<Address> Addresses { get; set; } = null!;

        #endregion
        
    }
}