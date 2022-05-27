using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;
using ChedzaApp.api.Models.UserAccess;

namespace ChedzaApp.api.Models.BlogPosts
{
    public class Post : EntityBase
    {
        public int BlogId { get; set; }
        [Display(Name ="Created By")]
        public int UserId { get; set; }
        [Display(Name ="Updated By")]
        public int UserId2 { get; set; }
        public string? Title { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? Content { get; set; }

        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(BlogId))]
        public virtual Blog? BlogNavigation { get; set; } 
        [ForeignKey(nameof(UserId))]
        public virtual User? CreatedBy { get; set; }
        [ForeignKey(nameof(UserId2))]
        public virtual User? UpdatedBy { get; set; }
        #endregion
        #region Navigation Properties(Retrieves Many Records)
        [InverseProperty(nameof(Comment.Post))]
        public virtual ICollection<Comment>? Comments { get; set; }
        #endregion
    }
}