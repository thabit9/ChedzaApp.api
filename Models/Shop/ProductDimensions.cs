using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class ProductDimensions : EntityBase
    {
        public int ProductId { get; set; }
        [Display(Name ="Mass")]
        public float Mass { get; set; }
        [Display(Name ="Length")]
        public float Length { get; set; }
        [Display(Name ="Width")]
        public float Width { get; set; }
        [Display(Name ="Height")]
        public float Height { get; set; }
        
        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        #endregion
    }
}