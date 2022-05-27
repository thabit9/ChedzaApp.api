using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class ProductRatings : EntityBase
    {
        public int ProductId { get; set; }
        public int ReviewedBy { get; set; }
        public float Rating { get; set; }
        [DataType(DataType.Text), MaxLength(256), 
         Display(Name ="IP Address")]
        public string IP_Address { get; set; } = null!;
        [DataType(DataType.MultilineText), MaxLength(500), 
         Display(Name ="Review")]
        public string Review { get; set; } = null!;

        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        [ForeignKey(nameof(ReviewedBy))]
        public Customer Customer { get; set; } = null!;
        #endregion
    }
}