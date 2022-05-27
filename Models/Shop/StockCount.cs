using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class StockCount : EntityBase
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public string StockStatus { get; set; } = null!;
        
        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        #endregion

    }
}