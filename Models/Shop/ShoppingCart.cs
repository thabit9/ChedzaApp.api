using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class ShoppingCart : ShoppingCartRecordBase
    {
        /*public int CustomerId { get; set; }
        [Required, EmailAddress,
         DataType(DataType.Text), MaxLength(256),
         Display(Name ="Customer Email")]
        public string? Email { get; set; }*/
        [ForeignKey(nameof(CustomerId))] 
        public Customer Customer { get; set; } = null!;
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }  = null!;
        //public virtual IEnumerable<ShoppingCartItems>? ShoppingCartItems { get; set; } 
    }
}