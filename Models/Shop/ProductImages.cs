using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class ProductImages : EntityBase
    {
        public int ProductId { get; set; }
        [DataType(DataType.Text), MaxLength(256), 
         Display(Name ="Product Image")]
        public string ImageUrl { get; set; } = null!;
        public bool IsMainImage { get; set; }
        public int ImageCount { get; set; }
        
        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        #endregion
    }
}