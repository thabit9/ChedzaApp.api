using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class ProductFeatures : EntityBase
    {
        public int ProductId { get; set; }
        [DataType(DataType.Text), MaxLength(256), 
         Display(Name ="Feature")]
        public string Feature { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256), 
         Display(Name ="Feature Detail")]
        public string Feature_Detail { get; set; } = null!;

        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        #endregion

    }
}