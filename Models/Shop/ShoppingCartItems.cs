using System.ComponentModel.DataAnnotations;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class ShoppingCartItems : EntityBase
    {
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Product Name")]
        public string ProductName { get; set; } = null!;

        #region Navigation Properties(Retrieves Many Records)
        public ShoppingCart ShoppingCart { get; set; } = null!;  
        public Product Product { get; set; } = null!;
        #endregion 
    }
}