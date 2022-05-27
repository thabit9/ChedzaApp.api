using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.BlogPosts
{
    public class Blog : EntityBase
    {
        public string? Title { get; set; }
        public string? BloggerName { get; set; }

        #region Navigation Properties(Retrieves Many Records)
        [InverseProperty(nameof(Post.BlogNavigation))]
        public virtual ICollection<Post>? Posts { get; set; }
        #endregion
    }
}