using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.BlogPosts
{
    public class Comment : EntityBase
    {
        public int PostId { get; set; }
        public string? Commentx { get; set; }

        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(PostId))]
        public virtual Post? Post { get; set; }
        #endregion
    }
}