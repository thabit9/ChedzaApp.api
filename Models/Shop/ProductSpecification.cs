using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class ProductSpecification : EntityBase 
    {
        public int ProductId { get; set; }
        [DataType(DataType.Text), MaxLength(256), 
         Display(Name ="Specification")]
        public string Specification { get; set; } = null!;
        [DataType(DataType.MultilineText), MaxLength(256), 
         Display(Name ="Detail")]
        public bool SpecificationDetail { get; set; }
        public string ImageUrl { get; set; } = null!;

        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        #endregion
    }
}